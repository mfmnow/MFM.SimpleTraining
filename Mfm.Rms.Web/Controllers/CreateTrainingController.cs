using System;
using System.Threading.Tasks;
using Mfm.Rms.Domain.Contracts;
using Mfm.Rms.Domain.Models;
using Mfm.Rms.Domain.Models.Exceptions;
using Mfm.Rms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mfm.Rms.Web.Controllers
{
    [Route("api/training")]
    public class CreateTrainingController : Controller
    {
        private readonly ITrainingDomain _trainingDomain;
        private readonly ILogger<CreateTrainingController> _logger;

        public CreateTrainingController(ITrainingDomain trainingDomain,
            ILogger<CreateTrainingController> logger) {
            _trainingDomain = trainingDomain;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<APIRequestResult<string>> CreateTraining([FromBody] TrainingModel trainingMode)
        {
            try {
                await _trainingDomain.CreateTraining(trainingMode);
                return new APIRequestResult<string>
                {
                    Success = true
                };
            }
            catch (InvalidTrainingModelException ex)
            {
                _logger.LogError(ex,ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };                
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }
    }
}
