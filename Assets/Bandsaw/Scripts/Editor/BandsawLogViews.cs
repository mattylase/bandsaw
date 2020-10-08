using UnityEngine;
using UnityEditor;

namespace Bandsaw
{
    public static class BandsawLogViews
    {
        private static GUILayoutOption[] logLineOptions = { GUILayout.Height(20) };
        public static void LogLineView(string log)
        {
            EditorGUILayout.LabelField(log, logLineOptions);
        }
    }

}