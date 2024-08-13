using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCIS.TTOS.EDI.DAL
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
                 where TContext : DbContext, new()
    {

        private readonly ILogger<TtosEDIContext> _logger;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private bool _disposed;

        private string _errorMessage = string.Empty;

        private IDbContextTransaction _objTran;

        //private Dictionary<string, object> _repositories;

        public UnitOfWork(ILogger<TtosEDIContext> logger, TtosEDIContext context)
        {
            Context = context;
            _logger = logger;
        }

        public Dictionary<Type, object> Repositories
        {
            get => _repositories;
            set => Repositories = value;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repositoryInstance = new GenericRepository<TEntity>(Context, _logger);
            _repositories.Add(typeof(TEntity), repositoryInstance);
            return repositoryInstance;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork<TContext> Members

        public TtosEDIContext Context { get; }

        public void BeginTransaction()
        {
            _objTran = Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _objTran.Commit();
        }
        public void EndTransaction()
        {
            if (_objTran != null)
            {
                CommitTransaction();
                _objTran?.Dispose();
            }
        }

        public void Rollback()
        {
            _objTran?.Rollback();
            _objTran?.Dispose();
        }

        /// <summary>
        /// Save with log into AuditTrail table
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            try
            {
                BeginTransaction();
                var dt = await Context.SaveChangesAsync();
                CommitTransaction();
                return dt;
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
        }

        public IGenericRepository<T> Repository<T>()
                where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(Context, _logger);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Context.Dispose();

            _disposed = true;
        }
    }
}
