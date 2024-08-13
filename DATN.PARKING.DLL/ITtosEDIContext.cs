using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TCIS.TTOS.EDI.DAL
{
    public interface ITtosEDIContext : IDisposable
    {

        DatabaseFacade Database { get; }
        Task<int> SaveAsync();
        Task<int> SaveChangesAsync();
    }
}
