using System;
using Raven.Client;

namespace Dywt.App.Infrastructure.RavenDB
{
    /// <summary>
    /// This class is a light abstraction on top of RavenDB.
    /// 
    /// According to the application's architecture, only commands should cause persistent changes.
    /// As such the only place that should commit changes to persistent storage is in the ICommandBus
    /// following the successful execution of the command handler for the current command.
    /// 
    /// It is feasible that at some point in the future a command handler might need to 
    /// deal with two or more persistent mediums (RavenDB and perhaps later SQL for user management).
    /// Therefore the IUnitOfWork is introduced to insert a layer of abstraction so that if needs be an 
    /// alternate implementation could be created that wraps the RavenDB session and an SQL session in 
    /// a system transaction, thus maintaining ACID whilst keeping the command bus implementation clean.
    /// </summary>
    public class RavenUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDocumentSession _session;
        private bool _isDisposed;

        public RavenUnitOfWork(IDocumentStore store)
        {
            _session = store.OpenSession();
            _isDisposed = false;
        }

        public IDocumentSession Session
        {
            get { return _session; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _isDisposed = true;
        }

        #endregion

        #region IUnitOfWork Members

        public void Commit()
        {
            if (_isDisposed)
            {
                throw new InvalidOperationException("This unit of work has already been disposed");
            }
            _session.SaveChanges();
            Dispose();
        }

        #endregion
    }
}