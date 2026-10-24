using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
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
        private bool reloaded;

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
            public string inputModule;
            public bool mousePresent;
            public bool focused;
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
            yield return ClickMenuButton("NewGamePanelShow");
            yield return null;
            var panel = FindObjectOfType<NewGamePanelScript>();
            if (panel == null) { FinishFailure("New game panel is missing"); yield break; }
            yield return ClickMenuButton("Novice");
            float deadline = Time.realtimeSinceStartup + 60f;
            while ((SceneManager.GetActiveScene().name != "Kordon" || Data.CharacterD == null ||
                Data.CharacterD.Count == 0) && Time.realtimeSinceStartup < deadline) yield return null;
            yield return new WaitForSecondsRealtime(3f);
            yield return new WaitForEndOfFrame();
            Capture("new-game");
            bool valid = SceneManager.GetActiveScene().name == "Kordon" &&
                Data.CharacterD != null && Data.CharacterD.Count > 0 && errors.Count == 0;
            if (valid)
            {
                SaveLoad.AAAAAAAAAAAAAAAAAAde("PCSmoke", true);
                string save = Path.Combine(Application.persistentDataPath, "CipherPCSmoke.json");
                if (!File.Exists(save) || new FileInfo(save).Length < 100)
                { FinishFailure("Saving did not produce game state"); yield break; }
                SceneManager.sceneLoaded += SceneLoaded;
                SaveLoad.AAAAAAAAAAAAAAAAcd("PCSmoke");
                deadline = Time.realtimeSinceStartup + 60f;
                while (!reloaded && Time.realtimeSinceStartup < deadline) yield return null;
                SceneManager.sceneLoaded -= SceneLoaded;
                yield return new WaitForSecondsRealtime(3f);
                yield return new WaitForEndOfFrame();
                Capture("reload");
                valid = reloaded && SceneManager.GetActiveScene().name == "Kordon" &&
                    Data.CharacterD != null && Data.CharacterD.Count > 0 && errors.Count == 0;
            }
            File.WriteAllText(Path.Combine(folder, "result.txt"), valid ? "PASS" : "FAIL");
            Application.Quit();
        }

        private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            reloaded = scene.name == "Kordon";
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Point { public int x, y; }
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string className, string title);
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr window, out uint process);
        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentProcessId();
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr window);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr window, ref Point point);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint flags, uint x, uint y, uint data, UIntPtr extra);

        private IEnumerator ClickMenuButton(string method)
        {
            Button target = null;
            foreach (var button in FindObjectsOfType<Button>())
                for (int i = 0; i < button.onClick.GetPersistentEventCount(); i++)
                    if (button.onClick.GetPersistentMethodName(i) == method) target = button;
            if (target == null) throw new InvalidOperationException("No UI button for " + method);
            var rectangle = target.GetComponent<RectTransform>();
            var canvas = target.GetComponentInParent<Canvas>();
            var camera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
            var position = RectTransformUtility.WorldToScreenPoint(camera,
                rectangle.TransformPoint(rectangle.rect.center));
            if (float.IsNaN(position.x) || float.IsNaN(position.y) ||
                float.IsInfinity(position.x) || float.IsInfinity(position.y) ||
                position.x < 0 || position.x >= Screen.width || position.y < 0 || position.y >= Screen.height)
                throw new InvalidOperationException("UI button outside the game viewport: " + method);
            IntPtr window = FindWindow("UnityWndClass", Application.productName);
            uint owner;
            if (window == IntPtr.Zero || GetWindowThreadProcessId(window, out owner) == 0 ||
                owner != GetCurrentProcessId())
                throw new InvalidOperationException("Cannot identify this game process's window");
            SetForegroundWindow(window);
            yield return new WaitForSecondsRealtime(0.2f);
            if (GetForegroundWindow() != window)
                throw new InvalidOperationException("Game window must own focus before its UI test");
            var point = new Point { x = (int)position.x, y = Screen.height - (int)position.y };
            if (!ClientToScreen(window, ref point) || !SetCursorPos(point.x, point.y))
                throw new InvalidOperationException("Cannot position the pointer inside the game window");
            // Injection is confined to this verified, foreground game window.
            mouse_event(0x0002, 0, 0, 0, UIntPtr.Zero);
            yield return new WaitForSecondsRealtime(0.12f);
            mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero);
            yield return new WaitForSecondsRealtime(0.4f);
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
                buttons = FindObjectsOfType<Button>().Length,
                inputModule = EventSystem.current == null || EventSystem.current.currentInputModule == null
                    ? "none" : EventSystem.current.currentInputModule.GetType().FullName,
                mousePresent = Input.mousePresent, focused = Application.isFocused,
                errors = errors.ToArray() };
            File.WriteAllText(Path.Combine(folder, stage + ".json"), JsonUtility.ToJson(report, true));
        }

        private void FinishFailure(string error)
        {
            File.WriteAllText(Path.Combine(folder, "result.txt"), "FAIL: " + error);
            Application.Quit();
        }
    }
}
