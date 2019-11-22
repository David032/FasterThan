using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloorGeneration))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FloorGeneration floorGen = (FloorGeneration)target;
        if (DrawDefaultInspector())
        {
            if (floorGen.autoUpdate)
            {
                floorGen.GenerateTiles();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            floorGen.GenerateTiles();
        }
    }
}