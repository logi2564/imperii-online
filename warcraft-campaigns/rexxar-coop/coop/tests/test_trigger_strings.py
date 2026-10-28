"""Real campaign text extraction, not a mocked display-string check."""
import json
import re
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
from build import MAPS, ROOT
from storm import Storm
from trigger_strings import parse_wts, parse_campaign_wts, resolve_string,write_wts
from unified_script import localize


class TriggerStrings(unittest.TestCase):
    def test_editor_comments_and_multiline(self):
        data = '\ufeff// header\r\nSTRING 7\r\n// Sound\\Dialogue\\voice.mp3\r\n\r\n{\r\nРексар\r\n// this is displayed text\r\nещё строка\r\n}\r\nSTRING 8\n{\n\n}\n'
        self.assertEqual(parse_wts(data), {7: 'Рексар\n// this is displayed text\nещё строка'.encode(), 8: b''})

    def test_fail_closed(self):
        for data in ['STRING 0\n{\nmissing end', 'STRING 0\n{\nx\n}\nSTRING 0\n{\nx\n}', 'STRING 0\nx']:
            with self.assertRaises(ValueError):
                parse_wts(data)
        with self.assertRaisesRegex(ValueError, 'TRIGSTR_13'):
            localize('call DisplayTextToPlayer(Player(0),0,0,"TRIGSTR_13")', {}, {})

    def test_literal_escaping_and_legacy_quotes(self):
        strings = {7: 'Реплика «Рексар»\n"цитата" и \\ путь'.encode()}
        self.assertEqual(resolve_string(b'\xf0\xff\x00\x80', strings), b'\xf0\xff\x00\x80')
        for value in ['TRIGSTR_007', '"TRIGSTR_007"', '\\"TRIGSTR_007\\"']:
            self.assertEqual(resolve_string(value, strings), strings[7].decode())
        code = '// "TRIGSTR_7"\ncall F("TRIGSTR_7", "\\\"TRIGSTR_7\\\"")'
        fixed = localize(code, strings, {})
        literals = re.findall(r'"(?:[^"\\]|\\.)*"', fixed.split('\n')[1])
        self.assertEqual([json.loads(v) for v in literals], [strings[7].decode()] * 2)
        self.assertTrue(fixed.startswith('// "TRIGSTR_7"'))

    def test_drekthar_is_not_a_terrain_tile(self):
        code="call CreateUnit(Player(5),'Odrt',10,20,0)\ncall CreateNUnitsAtLoc(1,'Odrt',Player(5),p,0)"
        self.assertEqual(localize(code, {}, {}),code)

    def test_all_seventeen_original_missions(self):
        storm = Storm()
        total = 0
        for name in MAPS:
            with self.subTest(mission=name):
                h = storm.open(ROOT / 'inputs' / (name + '.w3x'))
                try:
                    wts = storm.read(h, 'war3map.wts')
                    code = storm.read(h, 'war3map.j').decode()
                finally:
                    storm.close(h)
                strings = parse_campaign_wts(wts,name)
                self.assertEqual(parse_wts(write_wts(strings)),strings)
                self.assertEqual(len(strings), len(re.findall(r'(?m)^STRING\s+\d+', wts.decode('utf-8-sig'))))
                fixed = localize(code, strings, {})
                for line in code.splitlines():
                    if "'Odrt'" in line:
                        self.assertIn(line,fixed)
                # No unresolved quoted reference may reach the classic engine.
                self.assertIsNone(re.search(r'"TRIGSTR_\d+"', fixed))
                # Sound definitions and transmission sound handles are intact.
                original_sounds = re.findall(r'CreateSound\(([^\n]+)', code)
                self.assertEqual(re.findall(r'CreateSound\(([^\n]+)', fixed), original_sounds)
                total += len(strings)
                if name == 'OrcX01':
                    self.assertEqual(strings[121].decode(), 'Кентавр-огнепоклонник')
                    self.assertTrue(strings[323].decode().startswith('Постройте ферму.'))
                    self.assertIn('Город воинов.', strings[131].decode())
                    self.assertIn('Вот так-то, дружище...', strings[212].decode())
                    self.assertIn('call TransmissionFromUnitWithNameBJ', fixed)
                    self.assertIn(json.dumps(strings[131].decode(), ensure_ascii=False), fixed)
        self.assertGreater(total, 4500)


if __name__ == '__main__':
    unittest.main()
