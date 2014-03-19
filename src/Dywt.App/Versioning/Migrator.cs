using System.Collections.Generic;
using System.Linq;
using Dywt.App.Versioning.Migrations;
using Raven.Client;

namespace Dywt.App.Versioning
{
    public interface IMigrator
    {
        void UpgradeToLatest(IDocumentStore store);
    }

    public class Migrator : IMigrator
    {
        private static readonly object UpgradeLock = new object();

        private readonly IEnumerable<IMigration> _migrations;
        public Migrator(IEnumerable<IMigration> migrations)
        {
            _migrations = migrations;
        }
        public void UpgradeToLatest(IDocumentStore store)
        {
            lock (UpgradeLock)
            {
                using (var session = store.OpenSession())
                {
                    var version = session.Load<AppVersion>(AppVersion.DocumentId);

                    if (version == null)
                    {
                        version = new AppVersion(1, 0);
                        session.Store(version);
                    }
                    
                    version.Upgrade(store, _migrations);

                    session.SaveChanges();
                }
            }
        }
    }
}
