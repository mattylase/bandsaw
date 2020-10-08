using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CodeEditor;
using UnityEditor;

namespace Bandsaw
{
    public static class Saw
    {
        private static ILogger logger = Debug.unityLogger;
        private static BandsawLogHandler handler = new BandsawLogHandler();

        public static void Log(string tag, string log)
        {
            logger.Log(tag, log);
        }
    }

}