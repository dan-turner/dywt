using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dywt.App.Versioning.Migrations;
using Raven.Client;

namespace Dywt.App.Versioning
{
    public class AppVersion
    {
        public const string DocumentId = "App/Version";

        private int _current;
        private int? _previous;

        public AppVersion(int current, int previous)
        {
            _current = current;
            _previous = previous;
        }

        public string Id
        {
            get { return DocumentId; }
        }

        public int Current
        {
            get { return _current; }
        }

        public int? Previous
        {
            get { return _previous; }
        }

        public void Upgrade(IDocumentStore store, IEnumerable<IMigration> migrations)
        {
            _previous = Current;
            var applicable = migrations.Where(x => x.Version > Current).OrderBy(x => x.Version);

            foreach (var migration in applicable)
            {
                migration.Execute(store);
                _current = migration.Version;
            }
        }
    }
}
