using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dywt.Mobile.Notifications
{
    public enum NotificationType
    {
        Success,
        Info,
        Warn,
        Error
    }

    public class Notification
    {
        public Notification(NotificationType type, string message, object[] formatArgs)
        {
            Type = type;
            Message = message;
            FormatArgs = formatArgs;
        }

        public NotificationType Type { get; private set; }
        public string Message { get; private set; }
        public object[] FormatArgs { get; private set; }
    }
}