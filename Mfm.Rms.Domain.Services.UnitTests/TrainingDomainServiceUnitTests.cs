using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Domain.Models;
using Mfm.Rms.Domain.Models.Exceptions;
using Mfm.Rms.Domain.Services.UnitTests.MockProviders;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Rms.Domain.Services.UnitTests
{
    public class TrainingDomainServiceUnitTests
    {
        private readonly Mock<ITrainingDataAccess> _trainingDataAccessService;
        private readonly Mock<TrainingDomainService> _trainingDomainService;
        private readonly Mock<AppSettings> _mockedAppSettings;

        public TrainingDomainServiceUnitTests()
        {
            (_trainingDataAccessService, _trainingDomainService, _mockedAppSettings) =
                TrainingDomainServiceMockerProvider.GetMocks();
        }

        [Fact]
        public async Task CreateTraining_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            _trainingDomainService.Setup(t => t.IsValidModel(It.IsAny<TrainingModel>())).Returns(true);
            await _trainingDomainService.Object.CreateTraining(TrainingDomainServiceMockerProvider.MockedValidTrainingModel);

            _trainingDomainService.Verify(t => t.IsValidModel(TrainingDomainServiceMockerProvider.MockedValidTrainingModel), Times.Once);
            _trainingDataAccessService.Verify(t => t.CreateTraining(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), ""), Times.Once);
        }

        [Fact]
        public async Task CreateTraining_Should_Follow_LogicalFlow_On_InValid_Model()
        {
            _trainingDomainService.Setup(t => t.IsValidModel(It.IsAny<TrainingModel>())).Returns(false);

            await Assert.ThrowsAsync<InvalidTrainingModelException>(() => _trainingDomainService.Object.CreateTraining(TrainingDomainServiceMockerProvider.MockedValidTrainingModel));

            _trainingDomainService.Verify(t => t.IsValidModel(TrainingDomainServiceMockerProvider.MockedValidTrainingModel), Times.Once);
            _mockedAppSettings.Verify(a => a.InvalidDateMessage, Times.Once);
            _trainingDataAccessService.Verify(t => t.CreateTraining(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), ""), Times.Never);
        }

        [Fact]
        public void IsValidModel_Should_Return_True_If_Model_Is_Valid()
        {
            var result = _trainingDomainService.Object.IsValidModel(TrainingDomainServiceMockerProvider.MockedValidTrainingModel);

            Assert.True(result);
        }

        [Fact]
        public void IsValidModel_Should_Return_False_If_Model_Is_Not_Valid()
        {
            var result = _trainingDomainService.Object.IsValidModel(TrainingDomainServiceMockerProvider.MockedInvalidTrainingModel);

            Assert.False(result);
        }
    }
}