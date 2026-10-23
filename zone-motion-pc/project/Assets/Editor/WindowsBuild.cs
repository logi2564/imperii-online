#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ZoneMotionPC
{
    public static class EditorBuild
    {
        [MenuItem("Tools/Zone Motion/Build Windows x64")]
        public static void BuildWindows()
        {
            string[] scenes = EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path).ToArray();
            if (scenes.Length != 14 || scenes[0] != "Assets/Scens/Menu.unity")
                throw new InvalidOperationException("Expected the menu and all 13 game locations in Build Settings.");
            foreach (string scene in scenes)
                if (!File.Exists(scene)) throw new FileNotFoundException("Missing scene", scene);

            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.StandaloneWindows64 &&
                !EditorUserBuildSettings.SwitchActiveBuildTarget(
                    BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64))
                throw new InvalidOperationException("Windows x64 Build Support is required.");

            string projectRoot = Directory.GetParent(Application.dataPath).FullName;
            string folder = Path.GetFullPath(Path.Combine(projectRoot, "../dist/ZoneMotionPC"));
            Directory.CreateDirectory(folder);
            string executable = Path.Combine(folder, "ZoneMotionPC.exe");
#if UNITY_2018_1_OR_NEWER
            var report = BuildPipeline.BuildPlayer(scenes, executable,
                BuildTarget.StandaloneWindows64, BuildOptions.None);
            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
                throw new InvalidOperationException("Windows build failed: " + report.summary.result);
#else
            string error = BuildPipeline.BuildPlayer(scenes, executable,
                BuildTarget.StandaloneWindows64, BuildOptions.None);
            if (!string.IsNullOrEmpty(error)) throw new InvalidOperationException(error);
#endif
            if (!File.Exists(executable))
                throw new FileNotFoundException("Unity did not produce the Windows executable", executable);
            Debug.Log("WINDOWS_BUILD_COMPLETE: " + executable);
        }
    }
}
#endif
