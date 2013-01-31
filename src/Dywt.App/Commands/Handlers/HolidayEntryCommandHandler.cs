using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dywt.App.Infrastructure;
using Dywt.Domain;
using Raven.Client;

namespace Dywt.App.Commands.Handlers
{
    public class HolidayEntryCommandHandler : ICommandHandler<HolidayEntryCommand>
    {
        private readonly IDocumentSession _session;
        private readonly UserId _userId;

        public HolidayEntryCommandHandler(IDocumentSession session, UserId userId)
        {
            _session = session;
            _userId = userId;
        }

        public void Execute(HolidayEntryCommand command)
        {
            for(var date = command.DateFrom.Value; date <= command.DateTo; date = date.AddDays(1))
            {
                var entry = new DayEntry(_userId, date, false, SystemTime.UtcNow());
                _session.Store(entry);
            }
        }
    }
}
