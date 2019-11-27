using Mfm.Rms.Domain.Contracts;
using Mfm.Rms.Domain.Models.Exceptions;
using Mfm.Rms.Web.Controllers;
using Mfm.Rms.Web.UnitTests.MockProviders;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Rms.Web.UnitTests
{
    public class CreateTrainingControllerUnitTests
    {
        private readonly Mock<ITrainingDomain> _mockedTrainingDomain;
        private readonly Mock<ILogger<CreateTrainingController>> _mockedLogger;
        private readonly Mock<CreateTrainingController> _createTrainingController;

        public CreateTrainingControllerUnitTests()
        {
            _mockedTrainingDomain = new Mock<ITrainingDomain>();
            _mockedLogger = new Mock<ILogger<CreateTrainingController>>();
            _createTrainingController = new Mock<CreateTrainingController>(_mockedTrainingDomain.Object, _mockedLogger.Object)
            { CallBase = true };
        }

        [Fact]
        public async Task CreateTraining_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _createTrainingController.Object.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel);

            _mockedTrainingDomain.Verify(t => t.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel), Times.Once);
        }

        [Fact]
        public async Task CreateTraining_Should_Return_Right_Model_On_Success()
        {
            var result = await _createTrainingController.Object.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel);

            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            _mockedTrainingDomain.Verify(t => t.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel), Times.Once);
        }

        [Fact]
        public async Task CreateTraining_Should_Return_Right_Model_On_ValidationError ()
        {
            _mockedTrainingDomain.Setup(t => t.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel)).Throws(
                new InvalidTrainingModelException(CreateTrainingControllerMockerProvider.MockedErrorMessage)
                );
            var result = await _createTrainingController.Object.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel);

            Assert.False(result.Success);
            Assert.Equal(result.ErrorMessage, CreateTrainingControllerMockerProvider.MockedErrorMessage);
            _mockedTrainingDomain.Verify(t => t.CreateTraining(CreateTrainingControllerMockerProvider.MockedTrainingModel), Times.Once);
        }
    }
}