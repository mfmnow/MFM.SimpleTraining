using System.Threading.Tasks;
using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Domain.Contracts;
using Mfm.Rms.Domain.Models;
using Mfm.Rms.Domain.Models.Exceptions;

namespace Mfm.Rms.Domain.Services
{
    public class TrainingDomainService : ITrainingDomain
    {
        private readonly ITrainingDataAccess _trainingDataAccess;
        private readonly AppSettings _appSettings;

        public TrainingDomainService(ITrainingDataAccess trainingDataAccess, AppSettings appSettings)
        {
            _trainingDataAccess = trainingDataAccess;
            _appSettings = appSettings;
        }

        public virtual async Task CreateTraining(TrainingModel trainingModel)
        {
            if (!IsValidModel(trainingModel)) {
                throw new InvalidTrainingModelException(_appSettings.InvalidDateMessage);
            }
            await _trainingDataAccess.CreateTraining(trainingModel.Name, trainingModel.StartDate, trainingModel.EndDate);
        }

        public virtual bool IsValidModel(TrainingModel trainingModel)
        {
            return trainingModel.EndDate.Date > trainingModel.StartDate.Date;
        }
    }
}
