using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    static void PerformAndroidBuild()
    {
        //    GetCommandLineArgs
        string[] defaultScene = {
            "Assets/Scenes/SampleScene.unity",
            };

        BuildPipeline.BuildPlayer(defaultScene, "Builds\\Android\\Asteroids.apk",
            BuildTarget.Android, BuildOptions.None);
    }

    static void PerformWindowsBuild()
    {
        //    GetCommandLineArgs

        string[] defaultScene = {
            "Assets/Scenes/SampleScene.unity",
            };

        BuildPipeline.BuildPlayer(defaultScene, "Builds\\Windows\\Asteroids.exe",
            BuildTarget.StandaloneWindows, BuildOptions.None);
    }

}
