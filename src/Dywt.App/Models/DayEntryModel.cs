using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dywt.App.Commands;

namespace Dywt.App.Models
{
    public class DayEntryModel
    {
        private readonly DayEntryCommand _command;

        public DayEntryModel(DateTime date)
        {
            _command = new DayEntryCommand() {Date = date.Date};
        }

        public Previous PreviousAnswer { get; set; }

        public DateTime PreviousDay
        {
            get { return Command.Date.AddDays(-1); }
        }

        public DateTime NextDay
        {
            get { return Command.Date.AddDays(1); }
        }

        public DayEntryCommand Command
        {
            get { return _command; }
        }

        public class Previous
        {
            public Previous(int hoursWorked, DateTimeOffset timeStamp)
            {
                HoursWorked = hoursWorked;
                TimeStamp = timeStamp;
            }

            public int HoursWorked { get; private set; }
            public DateTimeOffset TimeStamp { get; private set; }
        }
    }
}
