using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchSystem.Others.Enums.Job;

namespace SearchSystem.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public JobCity City { get; set; }
        public JobCategory Category { get; set; }
        public JobEmployment Employment { get; set; }
        public bool WithoutExperience { get; set; }
        public bool RemoteInterview { get; set; }
        public JobWorkplace Workplace { get; set; }
        public JobPosition Position { get; set; }
        public JobProvider Provider { get; set; }
        public int Salary { get; set; }
        public JobPaidLeave PaidLeave { get; set; }
        public JobLanguage Language { get; set; }
        public DateTime PostTime { get; set; }
    }
}
