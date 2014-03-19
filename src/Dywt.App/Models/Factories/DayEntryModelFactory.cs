using Dywt.App.Infrastructure;
using Dywt.Domain;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Models.Factories
{
    public class DayEntryModelFactory : IModelFactory<DateTime, DayEntryModel>
    {
        private readonly IDocumentSession _session;
        private readonly UserId _userId;

        public DayEntryModelFactory(IDocumentSession session, UserId userId)
        {
            _session = session;
            _userId = userId;
        }

        public DayEntryModel Create(DateTime input)
        {
            var entryId = DayEntry.GenerateId(_userId, input);

            var entry = _session.Load<DayEntry>(entryId);

            var model = new DayEntryModel(input);

            if (entry != null)
            {
                var didYouWork = entry.HoursWorked > 0;
                model.PreviousAnswer = new DayEntryModel.Previous(didYouWork, UserTime.FromUtc(entry.Timestamp));
            }

            return model;
        }
    }
}
