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
        string[] defaultScene = {
            "Assets/Scenes/SampleScene.unity",
            "C:\\Users\\hehexd\\Asteroids\\Assets\\Scenes\\SampleScene.unity",
            };

        BuildPipeline.BuildPlayer(defaultScene, "C:\\Users\\hehexd\\Asteroids\\Builds\\Android\\Asteroids.apk",
            BuildTarget.Android, BuildOptions.None);
    }

}
