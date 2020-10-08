using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bandsaw
{
    public class MainWindow : EditorWindow
    {
        Vector2 scrollPosition = Vector2.zero;
        List<string> logs = new List<string>();

        void OnGUI()
        {
            scrollPosition = new Vector2(0, logs.Count * 20);
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            logs.ForEach(l => BandsawLogViews.LogLineView(l));
            EditorGUILayout.EndScrollView();
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }


        [MenuItem("Bandsaw/Logger")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(MainWindow));
        }
    }
}