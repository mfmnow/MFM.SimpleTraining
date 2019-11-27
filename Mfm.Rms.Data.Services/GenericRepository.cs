using System.Threading.Tasks;
using Mfm.Rms.Data.Contracts;

namespace Mfm.Rms.Data.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RmsTrainingDbContext _context;

        public GenericRepository(RmsTrainingDbContext rmsTrainingDbContext)
        {
            _context = rmsTrainingDbContext;
        }

        public virtual async Task Create(T entity)
        {
            _context.Set<T>();
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
