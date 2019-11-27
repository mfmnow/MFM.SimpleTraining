using Mfm.Rms.Data.Models;
using Mfm.Rms.Data.Services.UnitTests.MockProviders;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Rms.Data.Services.UnitTests.Services
{
    public class TrainingDataAccessServiceUnitTests
    {
        private readonly Mock<TrainingDataAccessService> _trainingDataAccessService;

        public TrainingDataAccessServiceUnitTests()
        {
            _trainingDataAccessService = TrainingDataAccessServiceMockerProvider.GetMockedDataAccessService();
        }

        [Fact]
        public async Task CreateTraining_Should_Follow_LogicalFlow()
        {
            await _trainingDataAccessService.Object.CreateTraining(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            _trainingDataAccessService.Verify(t => t.Create(It.IsAny<Training>()), Times.Once);
        }
    }
}
