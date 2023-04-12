using UnityEngine;

namespace Game.Scripts.Helper
{
    public static class Logger
    {
        public static void Log(LogMessage messageType, string message, bool logActive = true)
        {
            if (!logActive) return;

            string color = messageType switch
            {
                LogMessage.Info => "white",
                LogMessage.Warning => "yellow",
                LogMessage.Error => "red",
                _ => ""
            };

            Debug.Log($"<color={color}>{message}</color>");
        }
    }

    public enum LogMessage
    {
        Info,
        Warning,
        Error
    }
}