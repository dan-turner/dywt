using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dywt.App.Infrastructure;
using Dywt.Domain;
using Raven.Client;

namespace Dywt.App.Models.Factories
{
    public class MonthViewModelFactory : IModelFactory<DateTime, MonthViewModel>
    {
        private readonly IDocumentSession _session;
        private readonly UserId _userId;

        public MonthViewModelFactory(IDocumentSession session, UserId userId)
        {
            _session = session;
            _userId = userId;
        }

        public MonthViewModel Create(DateTime theFirst)
        {
            var dateFrom = theFirst;
            var dateTo = theFirst.AddMonths(1).AddDays(-1);

            while(dateFrom.DayOfWeek != DayOfWeek.Monday)
            {
                dateFrom = dateFrom.AddDays(-1);
            }
            while (dateTo.DayOfWeek != DayOfWeek.Sunday)
            {
                dateTo = dateTo.AddDays(1);
            }

            var entries = _session.Query<DayEntry>().Where(x => x.UserId.Value == _userId.Value && x.Date >= dateFrom && x.Date <= dateTo).ToList();

            var model = new MonthViewModel(theFirst);

            for (var date = dateFrom; date <= dateTo; date = date.AddDays(1))
            {
                var entry = entries.SingleOrDefault(x => x.Date.Date.Equals(date.Date));
                var hoursWorked = (entry != null) ? entry.HoursWorked : (int?)null;
                var tile = new MonthViewModel.Tile(date, hoursWorked);
                model.Add(tile);
            }

            return model;
        }
    }
}
