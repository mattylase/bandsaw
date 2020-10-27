using UnityEngine;
using UnityEditor;

namespace Bandsaw
{
    public static class BandsawLogViews
    {
        private const int LINE_HEIGHT = 30;
        private const int TAG_WIDTH = 125;
        private const int TAG_HEIGHT = 15;
        private const int TIME_HEIGHT = 15;
        private const int LEVEL_HEIGHT = 15;
        private const int TIME_WIDTH = 75;
        private static GUIStyle tagStyle = new GUIStyle(EditorStyles.boldLabel);
        private static GUIStyle levelStyle = new GUIStyle(EditorStyles.boldLabel);
        private static GUIStyle messageStyle = new GUIStyle(EditorStyles.label);
        private static GUIStyle timeStyle = new GUIStyle(EditorStyles.label);
        private static GUIStyle metaHorizontalStyle = new GUIStyle(EditorStyles.label);
        private static GUILayoutOption[] metaVerticalOptions = { GUILayout.MaxWidth(10), GUILayout.Height(30), GUILayout.ExpandWidth(false) };
        private static GUILayoutOption[] metaHorizontalOptions = { GUILayout.Width(5), GUILayout.ExpandWidth(false) };
        private static GUILayoutOption[] logLineOptions = { GUILayout.Height(LINE_HEIGHT), GUILayout.ExpandHeight(false) };
        private static GUILayoutOption[] logLevelOptions = { GUILayout.Height(LEVEL_HEIGHT), GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false) };
        private static GUILayoutOption[] logTagOptions = { GUILayout.Height(TAG_HEIGHT), GUILayout.Width(TAG_WIDTH), GUILayout.ExpandHeight(false) };
        private static GUILayoutOption[] logTimeOptions = { GUILayout.Height(TIME_HEIGHT), GUILayout.Width(TIME_WIDTH), GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false) };
        private static Color32 backgroundColor = new Color32(22, 22, 22, 25);
        private static Color32 warningColor = new Color32(200, 200, 51, 50);
        private static Color32 errorColor = new Color32(225, 51, 76, 50);
        private static Texture2D backgroundTexture = MakeBackgroundTexture(backgroundColor);

        public static void Setup()
        {
            levelStyle.alignment = TextAnchor.MiddleLeft;
            levelStyle.margin.left = 0;
            levelStyle.margin.right = 0;
            levelStyle.padding.left = 0;

            metaHorizontalStyle.margin.left = 0;
            metaHorizontalStyle.padding.left = 0;

            timeStyle.alignment = TextAnchor.MiddleLeft;
            timeStyle.margin.left = 0;
            timeStyle.margin.right = 0;
        }

        public static void LogLineView(Log log, int pos)
        {

            var bg = new Color32(44, 44, 44, 50);
            var style = new GUIStyle(EditorStyles.label);
            var other = new GUIStyle(EditorStyles.label);
            style.active.background = MakeBackgroundTexture(backgroundColor);
            style.normal.background = MakeBackgroundTexture(backgroundColor);
            style.margin.left = 0;
            other.margin.left = 0;

            var rect = pos % 2 == 0 ? EditorGUILayout.BeginHorizontal(other, logLineOptions) : EditorGUILayout.BeginHorizontal(style, logLineOptions);

            var metaStyle = new GUIStyle(style);
            switch (log.level)
            {
                case LogLevel.Warn:
                    metaStyle.normal.background = MakeBackgroundTexture(warningColor);
                    break;
                case LogLevel.Error:
                    metaStyle.normal.background = MakeBackgroundTexture(errorColor);
                    break;
            }

            EditorGUILayout.BeginVertical(metaStyle, metaHorizontalOptions);
            EditorGUILayout.LabelField(log.tag, tagStyle, logTagOptions);
            EditorGUILayout.BeginHorizontal(metaHorizontalOptions);
            ShowLogLevelField(log.level);
            EditorGUILayout.LabelField(log.dateTime.ToLongTimeString(), timeStyle, logTimeOptions);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField(log.content, messageStyle, logLineOptions);
            EditorGUILayout.EndHorizontal();
        }

        private static void ShowLogLevelField(LogLevel level)
        {
            var letter = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    letter = "Info";
                    break;
                case LogLevel.Warn:
                    letter = "Warn";
                    break;
                case LogLevel.Error:
                    letter = "Error";
                    break;
            }

            levelStyle.alignment = TextAnchor.MiddleLeft;
            EditorGUILayout.LabelField(letter, levelStyle, logLevelOptions);
        }

        private static Texture2D MakeBackgroundTexture(Color color)
        {
            var pixels = new Color[4];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            var result = new Texture2D(2, 2);
            result.SetPixels(pixels);
            result.Apply();
            return result;
        }
    }

}