using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}


