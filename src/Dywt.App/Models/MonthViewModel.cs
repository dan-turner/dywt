using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Models
{
    public class MonthViewModel
    {
        public MonthViewModel(DateTime theFirst)
        {
            TheFirst = theFirst;
            Tiles = new List<Tile>();
        }

        public DateTime TheFirst { get; private set; }
        public DateTime PreviousMonth
        {
            get { return TheFirst.AddMonths(-1); }
        }
        public DateTime NextMonth
        {
            get { return TheFirst.AddMonths(1); }
        }
        public IList<Tile> Tiles { get; private set; }

        public class Tile
        {
            public Tile(DateTime date, bool? didYouWork)
            {
                Date = date;
                DidYouWork = didYouWork;
            }

            public DateTime Date { get; private set; }
            public bool? DidYouWork { get; private set; }
        }
    }
}
