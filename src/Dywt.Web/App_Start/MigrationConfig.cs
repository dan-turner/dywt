using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dywt.App.Versioning;
using Raven.Client;

namespace Dywt.Web
{
    public static class MigrationConfig
    {
        public static void UpgradeToLatest(IDocumentStore store)
        {
            var migrator = DependencyResolver.Current.GetService<IMigrator>();
            migrator.UpgradeToLatest(store);
        }
    }
}