using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;

namespace Dywt.App.Infrastructure.RavenDB
{
    public class ReadOnlyDocumentSession : IDocumentSession
    {
        private readonly IDocumentSession _session;
        public ReadOnlyDocumentSession(IDocumentSession session)
        {
            _session = session;
        }
        public ISyncAdvancedSessionOperation Advanced
        {
            get { return _session.Advanced; }
        }

        public void Delete<T>(T entity)
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public Raven.Client.Document.ILoaderWithInclude<T> Include<T, TInclude>(System.Linq.Expressions.Expression<Func<T, object>> path)
        {
            return _session.Include<T, TInclude>(path);
        }

        public Raven.Client.Document.ILoaderWithInclude<T> Include<T>(System.Linq.Expressions.Expression<Func<T, object>> path)
        {
            return _session.Include<T>(path);
        }

        public Raven.Client.Document.ILoaderWithInclude<object> Include(string path)
        {
            return _session.Include(path);
        }

        public TResult[] Load<TTransformer, TResult>(IEnumerable<string> ids, Action<ILoadConfiguration> configure) where TTransformer : Raven.Client.Indexes.AbstractTransformerCreationTask, new()
        {
            return _session.Load<TTransformer, TResult>(ids, configure);
        }

        public TResult[] Load<TTransformer, TResult>(params string[] ids) where TTransformer : Raven.Client.Indexes.AbstractTransformerCreationTask, new()
        {
            return _session.Load<TTransformer, TResult>(ids);
        }

        public TResult Load<TTransformer, TResult>(string id, Action<ILoadConfiguration> configure) where TTransformer : Raven.Client.Indexes.AbstractTransformerCreationTask, new()
        {
            return _session.Load<TTransformer, TResult>(id, configure);
        }

        public TResult Load<TTransformer, TResult>(string id) where TTransformer : Raven.Client.Indexes.AbstractTransformerCreationTask, new()
        {
            return _session.Load<TTransformer, TResult>(id);
        }

        public T[] Load<T>(IEnumerable<ValueType> ids)
        {
            return _session.Load<T>(ids);
        }

        public T[] Load<T>(params ValueType[] ids)
        {
            return _session.Load<T>(ids);
        }

        public T Load<T>(ValueType id)
        {
            return _session.Load<T>(id);
        }

        public T[] Load<T>(IEnumerable<string> ids)
        {
            return _session.Load<T>(ids);
        }

        public T[] Load<T>(params string[] ids)
        {
            return _session.Load<T>(ids);
        }

        public T Load<T>(string id)
        {
            return _session.Load<T>(id);
        }

        public Raven.Client.Linq.IRavenQueryable<T> Query<T, TIndexCreator>() where TIndexCreator : Raven.Client.Indexes.AbstractIndexCreationTask, new()
        {
            return _session.Query<T, TIndexCreator>();
        }

        public Raven.Client.Linq.IRavenQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public Raven.Client.Linq.IRavenQueryable<T> Query<T>(string indexName, bool isMapReduce = false)
        {
            return _session.Query<T>(indexName, isMapReduce);
        }

        public void SaveChanges()
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public void Store(dynamic entity, string id)
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public void Store(dynamic entity)
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public void Store(object entity, Raven.Abstractions.Data.Etag etag, string id)
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public void Store(object entity, Raven.Abstractions.Data.Etag etag)
        {
            throw new InvalidOperationException("Not allowed on read-only session");
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
