using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Units.Data
{
    public interface IHasTimeStamps
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }

    public abstract class TimeStamps : IHasTimeStamps
    {
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
