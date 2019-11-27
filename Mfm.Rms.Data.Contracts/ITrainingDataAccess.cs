using System;
using System.Threading.Tasks;

namespace Mfm.Rms.Data.Contracts
{
    public interface ITrainingDataAccess
    {
        Task CreateTraining(string name, DateTime startDate, DateTime endDate, string createdBy="");
    }
}
