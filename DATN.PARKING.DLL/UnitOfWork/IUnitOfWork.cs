using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL
{
    public interface IUnitOfWork<out TContext>
            where TContext : DbContext, new()
    {
        ParkingContext Context { get; }

        void BeginTransaction();

        void CommitTransaction();

        void EndTransaction();
        void Rollback();

        Task<int> SaveAsync();

        IGenericRepository<T> Repository<T>()
                where T : class;
    }
}
