using Mfm.Rms.Domain.Models;
using System.Threading.Tasks;

namespace Mfm.Rms.Domain.Contracts
{
    public interface ITrainingDomain
    {
        Task CreateTraining(TrainingModel trainingModel);
        bool IsValidModel(TrainingModel trainingModel);
    }
}
