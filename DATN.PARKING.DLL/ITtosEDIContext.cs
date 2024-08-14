using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DATN.PARKING.DLL
{
    public interface ITtosEDIContext : IDisposable
    {

        DatabaseFacade Database { get; }
        Task<int> SaveAsync();
        Task<int> SaveChangesAsync();
    }
}
