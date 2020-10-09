using UnityEngine;
using UnityEditor;

namespace Bandsaw
{
    public static class BandsawLogViews
    {
        private static GUILayoutOption[] logLineOptions = { GUILayout.Height(20) };
        public static void LogLineView(Log log)
        {
            EditorGUILayout.LabelField(log.content, logLineOptions);
        }
    }

}