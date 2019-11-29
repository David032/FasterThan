using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallGeneration))]
public class WallGenerator: Editor
{
    public override void OnInspectorGUI()
    {
        WallGeneration wallGen = (WallGeneration)target;
        if (DrawDefaultInspector())
        {
            if (wallGen.autoUpdate)
            {
                wallGen.GenerateWall();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            wallGen.GenerateWall();
        }
    }
}