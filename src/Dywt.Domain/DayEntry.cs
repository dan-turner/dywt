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
        private readonly bool _didYouWork;
        private readonly DateTime _timestamp;

        public DayEntry(UserId userId, DateTime date, bool didYouWork, DateTime timestamp)
        {
            _userId = userId;
            _date = date;
            _didYouWork = didYouWork;
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
        public bool DidYouWork
        {
            get { return _didYouWork; }
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
