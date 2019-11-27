using System;

namespace Mfm.Rms.Data.Models
{
    public class Training: RmsTrainingEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
