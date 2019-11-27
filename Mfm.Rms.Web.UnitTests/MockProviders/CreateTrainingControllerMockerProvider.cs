using Mfm.Rms.Domain.Models;
using System;

namespace Mfm.Rms.Web.UnitTests.MockProviders
{
    internal class CreateTrainingControllerMockerProvider
    {
        public static string MockedErrorMessage = "MockedErrorMessage";
        public static TrainingModel MockedTrainingModel = new TrainingModel
        {
            Name = "",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };
    }
}
