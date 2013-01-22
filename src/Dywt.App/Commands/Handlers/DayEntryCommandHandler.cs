using Dywt.Domain;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Commands.Handlers
{
    public class DayEntryCommandHandler : ICommandHandler<DayEntryCommand>
    {
        private readonly IDocumentSession _session;
        private readonly UserId _userId;

        public DayEntryCommandHandler(IDocumentSession session, UserId userId)
        {
            _session = session;
            _userId = userId;
        }

        public void Execute(DayEntryCommand command)
        {
            var entry = new DayEntry(_userId, command.Date, command.DidYouWork, SystemTime.UtcNow());
            _session.Store(entry);
        }
    }
}
