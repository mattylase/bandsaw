using System;
using UnityEngine;

namespace Bandsaw
{
    public class BandsawLogHandler : ILogHandler
    {
        private ILogHandler defaultHandler = Debug.unityLogger.logHandler;

        public BandsawLogHandler()
        {
            Debug.unityLogger.logHandler = this;
        }

        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            defaultHandler.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            defaultHandler.LogException(exception, context);
        }
    }

}