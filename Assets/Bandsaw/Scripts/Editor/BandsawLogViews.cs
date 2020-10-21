using UnityEngine;
using UnityEditor;

namespace Bandsaw
{
    public static class BandsawLogViews
    {
        private const int LINE_HEIGHT = 30;
        private const int TAG_WIDTH = 150;
        private static GUIStyle tagStyle = new GUIStyle(EditorStyles.boldLabel);
        private static GUIStyle levelStyle = new GUIStyle(EditorStyles.boldLabel);
        private static GUIStyle messageStyle = new GUIStyle(EditorStyles.label);
        private static GUILayoutOption[] logLineOptions = { GUILayout.Height(LINE_HEIGHT) };
        private static GUILayoutOption[] logLevelOptions = { GUILayout.Height(LINE_HEIGHT), GUILayout.Width(30), GUILayout.ExpandWidth(false) };
        private static GUILayoutOption[] logTagOptions = { GUILayout.Height(LINE_HEIGHT), GUILayout.Width(TAG_WIDTH) };


        public static void LogLineView(Log log, int pos)
        {

            var bg = new Color32(44, 44, 44, 50);
            var r = EditorGUILayout.BeginHorizontal();

            //EditorGUI.DrawRect(new Rect(0, pos, r.width + 50, LINE_HEIGHT), bg);

            ShowLogLevelField(log.level);
            EditorGUILayout.LabelField(log.tag, tagStyle, logTagOptions);
            EditorGUILayout.LabelField(log.content, messageStyle, logLineOptions);
            EditorGUILayout.EndHorizontal();
        }

        private static void ShowLogLevelField(LogLevel level)
        {
            var letter = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    letter = "I";
                    break;
                case LogLevel.Warn:
                    letter = "W";
                    break;
                case LogLevel.Error:
                    letter = "E";
                    break;
            }

            levelStyle.alignment = TextAnchor.MiddleCenter;
            EditorGUILayout.LabelField(letter, levelStyle, logLevelOptions);
        }
    }

}