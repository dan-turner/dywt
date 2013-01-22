using System;
using System.Collections.Generic;

namespace Dywt.Mobile.Notifications
{
    public interface INotifier
    {
        void Success(string message, params object[] formatArgs);
        void Info(string message, params object[] formatArgs);
        void Warn(string message, params object[] formatArgs);
        void Error(string message, params object[] formatArgs);
        void Push(IEnumerable<Notification> notifications);
        IEnumerable<Notification> Pop();
    }

    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Success(string message, params object[] formatArgs)
        {
            _notifications.Add(new Notification(NotificationType.Success, message, formatArgs));
        }

        public void Info(string message, params object[] formatArgs)
        {
            _notifications.Add(new Notification(NotificationType.Info, message, formatArgs));
        }

        public void Warn(string message, params object[] formatArgs)
        {
            _notifications.Add(new Notification(NotificationType.Warn, message, formatArgs));
        }

        public void Error(string message, params object[] formatArgs)
        {
            _notifications.Add(new Notification(NotificationType.Error, message, formatArgs));
        }

        public void Push(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public IEnumerable<Notification> Pop()
        {
            var notifications = _notifications.ToArray();
            _notifications.Clear();
            return notifications;
        }
    }
}