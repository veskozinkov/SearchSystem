using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchSystem.Others;

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
        public List<JobWorkplace> Workplaces { get; set; }
        public JobPosition Position { get; set; }
        public JobProvider Provider { get; set; }
        public int Salary { get; set; }
        public int PaidLeave { get; set; }
        public List<JobLanguage> Languages { get; set; }
        public DateTime PostTime { get; set; }
    }
}
