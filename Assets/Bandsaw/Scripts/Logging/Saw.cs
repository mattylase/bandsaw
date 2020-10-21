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

            var log = new Log(LogLevel.Info, tag, message);
            BandsawWindow.SubmitLog(log);
        }

        public static void Warn(string tag, string message)
        {
            logger.Log(tag, message);

            var log = new Log(LogLevel.Warn, tag, message);
            BandsawWindow.SubmitLog(log);
        }

        public static void Error(string tag, string message)
        {
            logger.Log(tag, message);

            var log = new Log(LogLevel.Error, tag, message);
            BandsawWindow.SubmitLog(log);
        }
    }

}