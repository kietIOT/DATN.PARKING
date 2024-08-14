using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
namespace DATN.PARKING.DLL
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable
                 where T : class
    {
        private bool _isDisposed;
        private readonly ILogger<ParkingContext> _logger;
        internal ParkingContext context;
        internal DbSet<T> Entities;
        public GenericRepository(ParkingContext context, ILogger<ParkingContext> logger)
        {
            this.context = context;
            this.Entities = context.Set<T>();
            _logger = logger;
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
            _isDisposed = true;
        }

        #endregion

        #region IGenericRepository<T> Members

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>,
                                            IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = Entities;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query)
                            .ToList();
                }
                var t = query.AsSingleQuery();

                return query.ToList().RemoveWhiteSpaceForList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from Get() Method.");
                return null;
            }
        }

        public virtual IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includeProperties = "")
        {
            try
            {

                IQueryable<T> query = Entities;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from GetAsQueryable() Method.");
                return null;
            }
        }


        public virtual IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                             string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = Entities;

                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query)
                            .ToList();
                }

                return query.ToList().RemoveWhiteSpaceForList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from GetAll() Method.");
                return null;
            }
        }

        public virtual IQueryable<T> GetAllAsQueryable(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                       string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = Entities;
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from GetAllAsQueryable() Method.");
                return null;
            }
        }

        public virtual T GetById(object id)
        {
            try
            {
                return Entities.Find(id).RemoveWhiteSpace();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from GetById() Method.");
                return null;
            }
        }

        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                return Entities.Add(entity).Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from Insert() Method.");
                return null;
            }

        }

        public virtual T Update(T entity)
        {
            try
            {
                return SetEntryModified(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from Update() Method.");
                return null;
            }
        }

        public virtual T Delete(T entity)
        {
            try
            {
                T entityToDelete = Entities.Find(entity);
                return Entities.Remove(entityToDelete).Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from Delete() Method.");
                return null;
            }
        }

        public void DeleteMulti(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from DeleteMulti() Method.");
            }
        }

        public virtual T FindOne(Expression<Func<T, bool>> filter = null,
                                 string includeProperties = "")
        {
            try

            {
                IQueryable<T> query = Entities;

                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (filter != null)
                {
                    return query.FirstOrDefault(filter);
                }

                return query.FirstOrDefault().RemoveWhiteSpace();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from FindOne() Method.");
                return null;
            }
        }
        #endregion

        public virtual IEnumerable<T> GetEx(object obj = null,
                                            Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = Entities;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query)
                            .ToList();
                }
                return query.ToList().RemoveWhiteSpaceForList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from GetEx() Method.");
                return null;
            }
        }

        public virtual T SetEntryModified(T entity)
        {
            try
            {
                Entities.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from SetEntryModified() Method.");
                return null;
            }
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.Set<T>()
                       .AddRange(entities);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{typeof(GenericRepository<T>)}: Error throw from BulkInsert() Method.");
            }

        }
    }
}
