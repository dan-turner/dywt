using Raven.Client;
using Raven.Client.Document;

namespace Dywt.Web.Infrastructure
{
    public class DocumentStoreFactory
    {
        public static IDocumentStore Create(string connectionStringName)
        {
            var documentStore = new DocumentStore()
            {
                ConnectionStringName = connectionStringName
            };

            documentStore.Initialize();

            return documentStore;
        }
    }
}