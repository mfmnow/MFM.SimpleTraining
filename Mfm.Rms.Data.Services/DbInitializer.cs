using Mfm.Rms.Data.Contracts;

namespace Mfm.Rms.Data.Services
{
    public class DbInitializer: IDbInitializer
    {
        private readonly IRmsTrainingDbContext _context;
        public DbInitializer(IRmsTrainingDbContext rmsTrainingDbContext)
        {
            _context = rmsTrainingDbContext;
        }
        public void Initialize()
        {
            _context.EnsureCreated();
        }
    }
}
