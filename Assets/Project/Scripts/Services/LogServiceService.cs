using System;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using LogType = RedPanda.Project.Services.Interfaces.LogType;

namespace RedPanda.Project.Services
{
    public class LogServiceService : ILogService
    {
        public void Log(object message, LogType logType = LogType.Normal)
        {
            switch (logType)
            {
                case LogType.Normal:
                    Debug.Log(message);
                    break;

                case LogType.Error:
                    Debug.Log($"<color=red>{message}</color>");
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }
        }
    }
}