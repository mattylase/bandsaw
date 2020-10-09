using UnityEngine;

namespace Bandsaw
{
    public static class Saw
    {
        private static ILogger logger = Debug.unityLogger;
        private static BandsawLogHandler handler = new BandsawLogHandler();

        public static void Log(string tag, string message)
        {
            logger.Log(tag, message);

            var log = new Log(tag, message);
            BandsawWindow.SubmitLog(log);
        }
    }

}