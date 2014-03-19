using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Models
{
    public class MonthViewModel
    {
        private readonly IList<Tile> _tiles;

        public MonthViewModel(DateTime theFirst)
        {
            TheFirst = theFirst;
            _tiles = new List<Tile>();
            HoursWorkedThisMonth = 0;
        }

        public DateTime TheFirst { get; private set; }

        public int HoursWorkedThisMonth { get; private set; }

        public double DaysWorked
        {
            get { return HoursWorkedThisMonth/8.0; }
        }

        public DateTime PreviousMonth
        {
            get { return TheFirst.AddMonths(-1); }
        }
        public DateTime NextMonth
        {
            get { return TheFirst.AddMonths(1); }
        }
        public IEnumerable<Tile> Tiles { get { return _tiles; } }

        public void Add(Tile tile)
        {
            _tiles.Add(tile);

            if (tile.Date.Month == TheFirst.Month && tile.HoursWorked.HasValue)
            {
                HoursWorkedThisMonth += tile.HoursWorked.Value;
            }
        }

        public class Tile
        {
            public Tile(DateTime date, int? hoursWorked)
            {
                Date = date;
                HoursWorked = hoursWorked;
            }

            public DateTime Date { get; private set; }
            public int? HoursWorked { get; private set; }
        }
    }
}
