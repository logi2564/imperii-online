using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZoneMotionPC
{
    public static class NativeBootstrap
    {
        public static void Initialize()
        {
            DesktopControls.Install();
            if (Array.IndexOf(Environment.GetCommandLineArgs(), "--zone-motion-smoke") < 0 ||
                UnityEngine.Object.FindObjectOfType<NativeSmoke>() != null) return;
            var root = new GameObject("Native game validation");
            UnityEngine.Object.DontDestroyOnLoad(root);
            root.AddComponent<NativeSmoke>();
        }
    }

    public sealed class NativeSmoke : MonoBehaviour
    {
        private readonly List<string> errors = new List<string>();
        private string folder;

        [Serializable]
        public sealed class Report
        {
            public string stage;
            public string scene;
            public string renderer;
            public string device;
            public int frames;
            public int characters;
            public int buttons;
            public string[] errors;
        }

        private void Log(string message, string trace, LogType type)
        {
            if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
                errors.Add(message + "\n" + trace);
        }

        private IEnumerator Start()
        {
            folder = Environment.GetEnvironmentVariable("ZONEMOTION_SMOKE_OUTPUT");
            if (string.IsNullOrEmpty(folder)) folder = Application.persistentDataPath;
            Directory.CreateDirectory(folder);
            Application.logMessageReceived += Log;
            yield return new WaitForSecondsRealtime(3f);
            yield return new WaitForEndOfFrame();
            Capture("menu");
            var menu = FindObjectOfType<Menu>();
            if (menu == null) { FinishFailure("Menu component is missing"); yield break; }
            menu.NewGamePanelShow();
            yield return null;
            var panel = FindObjectOfType<NewGamePanelScript>();
            if (panel == null) { FinishFailure("New game panel is missing"); yield break; }
            panel.Novice();
            float deadline = Time.realtimeSinceStartup + 60f;
            while ((SceneManager.GetActiveScene().name != "Kordon" || Data.CharacterD == null ||
                Data.CharacterD.Count == 0) && Time.realtimeSinceStartup < deadline) yield return null;
            yield return new WaitForSecondsRealtime(3f);
            yield return new WaitForEndOfFrame();
            Capture("new-game");
            bool valid = SceneManager.GetActiveScene().name == "Kordon" &&
                Data.CharacterD != null && Data.CharacterD.Count > 0 && errors.Count == 0;
            File.WriteAllText(Path.Combine(folder, "result.txt"), valid ? "PASS" : "FAIL");
            Application.Quit();
        }

        private void Capture(string stage)
        {
            var texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();
            File.WriteAllBytes(Path.Combine(folder, stage + ".png"), texture.EncodeToPNG());
            Destroy(texture);
            var report = new Report { stage = stage, scene = SceneManager.GetActiveScene().name,
                renderer = SystemInfo.graphicsDeviceType.ToString(), device = SystemInfo.graphicsDeviceName,
                frames = Time.frameCount, characters = Data.CharacterD == null ? 0 : Data.CharacterD.Count,
                buttons = FindObjectsOfType<Button>().Length, errors = errors.ToArray() };
            File.WriteAllText(Path.Combine(folder, stage + ".json"), JsonUtility.ToJson(report, true));
        }

        private void FinishFailure(string error)
        {
            File.WriteAllText(Path.Combine(folder, "result.txt"), "FAIL: " + error);
            Application.Quit();
        }
    }
}
