﻿using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Bandsaw
{
    public class BandsawWindow : EditorWindow
    {
        Vector2 scrollPosition = Vector2.zero;
        [SerializeField]
        static List<Log> logs = new List<Log>();

        void OnGUI()
        {
            scrollPosition = new Vector2(0, logs.Count * 20);
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            for (int i = 0; i < logs.Count; i++)
            {
                BandsawLogViews.LogLineView(logs[i], i);
            }
            //logs.ForEach(l => BandsawLogViews.LogLineView(l, (logs.Count - 1) * 20));
            EditorGUILayout.EndScrollView();
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }

        void OnEnable()
        {
            this.titleContent = new GUIContent("Bandsaw Log", EditorGUIUtility.IconContent("UnityEditor.ConsoleWindow").image);
        }

        [MenuItem("Bandsaw/Logger")]
        public static void ShowWindow()
        {
            var window = EditorWindow.GetWindow(typeof(BandsawWindow));
            DontDestroyOnLoad(window);
        }

        public static void SubmitLog(Log log)
        {
            logs.Add(log);
        }
    }
}