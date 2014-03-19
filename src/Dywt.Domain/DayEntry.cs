using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.Domain
{
    public class DayEntry
    {
        private readonly UserId _userId;
        private readonly DateTime _date;
        private readonly int _hoursWorked;
        private readonly DateTime _timestamp;

        public DayEntry(UserId userId, DateTime date, int hoursWorked, DateTime timestamp)
        {
            _userId = userId;
            _date = date;
            _hoursWorked = hoursWorked;
            _timestamp = timestamp;
        }

        public string Id
        {
            get { return GenerateId(UserId, Date); }
        }

        public UserId UserId
        {
            get { return _userId; }
        }

        public DateTime Date
        {
            get { return _date; }
        }
        public int HoursWorked
        {
            get { return _hoursWorked; }
        }
        public DateTime Timestamp
        {
            get { return _timestamp; }
        }

        public static string GenerateId(UserId userId, DateTime date)
        {
            return String.Format("dayentries/{0}/{1}", userId.Value, date.ToString("yyyy-MM-dd"));
        }
    }
}
