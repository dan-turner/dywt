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

        public DayEntryCommand Command
        {
            get { return _command; }
        }

        public class Previous
        {
            public Previous(bool didYouWork, DateTimeOffset timeStamp)
            {
                DidYouWork = didYouWork;
                TimeStamp = timeStamp;
            }

            public bool DidYouWork { get; private set; }
            public DateTimeOffset TimeStamp { get; private set; }
        }
    }
}
