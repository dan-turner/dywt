using Raven.Abstractions.Data;
using Raven.Client;

namespace Dywt.App.Versioning.Migrations
{
    public class HoursWorkedMigration : IMigration
    {
        public int Version
        {
            get { return 2; }
        }

        public void Execute(IDocumentStore store)
        {
            var operation = store.DatabaseCommands.UpdateByIndex(
                    "Raven/DocumentsByEntityName",
                    new IndexQuery { Query = "Tag:DayEntries" },
                    new ScriptedPatchRequest()
                    {
                        Script = @"
                        this.HoursWorked = this.DidYouWork ? 8 : 0;
                        delete this.DidYouWork;
                    "
                    }, true);
            operation.WaitForCompletion();
        }
    }
}
