using Mfm.Rms.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mfm.Rms.Data.Services.UnitTests.MockProviders
{
    internal class TrainingDataAccessServiceMockerProvider
    {
        public static IQueryable<Training> GetMockedData()
        {
            return new List<Training>
            {
                new Training
                {
                    Name = "Name",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1)
                }
            }.AsQueryable();
        }

        public static Mock<TrainingDataAccessService> GetMockedDataAccessService()
        {
            var mockedDbContext = RmsTrainingDbContextMockerProvider.GetMockedEngineDbContext<RmsTrainingDbContext, Training>(GetMockedData());
            var mockedDataAccessSerice = new Mock<TrainingDataAccessService>(mockedDbContext.Object) { CallBase = true };
            mockedDataAccessSerice =
               RmsTrainingDbContextMockerProvider.SetupDataAccessServices<TrainingDataAccessService, Training>
               (mockedDataAccessSerice, GetMockedData());
            return mockedDataAccessSerice;
        }
    }
}
