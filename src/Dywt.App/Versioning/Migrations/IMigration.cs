using Raven.Client;

namespace Dywt.App.Versioning.Migrations
{
    public interface IMigration
    {
        int Version { get; }

        void Execute(IDocumentStore store);
    }
}
