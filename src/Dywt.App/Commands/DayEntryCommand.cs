using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Commands
{
    public class DayEntryCommand
    {
        public DayEntryCommand()
        {
            HoursWorked = 8;
        }

        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
    }
}
