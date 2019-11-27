using System;

namespace Mfm.Rms.Domain.Models.Exceptions
{
    public class InvalidTrainingModelException: Exception
    {
        public InvalidTrainingModelException(string message): base(message)
        {
        }
    }
}
