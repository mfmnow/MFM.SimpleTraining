using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Domain.Models;
using Moq;
using System;

namespace Mfm.Rms.Domain.Services.UnitTests.MockProviders
{
    internal class TrainingDomainServiceMockerProvider
    {
        private static Mock<ITrainingDataAccess> _trainingDataAccessService;
        private static  Mock<TrainingDomainService> _trainingDomainService;
        private static Mock<AppSettings> _mockedAppSettings;

        public static TrainingModel MockedValidTrainingModel = new TrainingModel
        {
            Name = "",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };

        public static TrainingModel MockedInvalidTrainingModel = new TrainingModel
        {
            Name = "",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(-1)
        };

        public static (Mock<ITrainingDataAccess>, Mock<TrainingDomainService>, Mock<AppSettings>) GetMocks() {
            _trainingDataAccessService = new Mock<ITrainingDataAccess>();
            _mockedAppSettings = new Mock<AppSettings>();
            _mockedAppSettings.Setup(a => a.InvalidDateMessage).Returns("InvalidDateMessage");
            _trainingDomainService = new Mock<TrainingDomainService>(_trainingDataAccessService.Object, _mockedAppSettings.Object)
            { CallBase = true };

            return (_trainingDataAccessService, _trainingDomainService, _mockedAppSettings);
        }
    }
}
