using System;
using System.Threading.Tasks;
using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Data.Models;

namespace Mfm.Rms.Data.Services
{
    public class TrainingDataAccessService : GenericRepository<Training>, ITrainingDataAccess
    {
        private readonly IRmsTrainingDbContext _context;

        public TrainingDataAccessService(RmsTrainingDbContext rmsTrainingDbContext): base(rmsTrainingDbContext) {
            _context = rmsTrainingDbContext;
        }

        public async Task CreateTraining(string name, DateTime startDate, DateTime endDate, string createdBy = "")
        {
            var entity = new Training
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                CreatedBy = createdBy
            };
            await Create(entity);
        }
    }
}
