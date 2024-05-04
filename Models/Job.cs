using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchSystem.Others.Enums.Job;
using System.ComponentModel;

namespace SearchSystem.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("City")]
        public JobCity City { get; set; }

        [DisplayName("Category")]
        public JobCategory Category { get; set; }

        [DisplayName("Employment")]
        public JobEmployment Employment { get; set; }

        [DisplayName("Without experience")]
        public bool WithoutExperience { get; set; }

        [DisplayName("Remote interview")]
        public bool RemoteInterview { get; set; }

        [DisplayName("Workplace")]
        public JobWorkplace Workplace { get; set; }

        [DisplayName("Position")]
        public JobPosition Position { get; set; }

        [DisplayName("Provider")]
        public JobProvider Provider { get; set; }

        [DisplayName("Salary")]
        public int Salary { get; set; }

        [DisplayName("Paid leave")]
        public JobPaidLeave PaidLeave { get; set; }

        [DisplayName("Language")]
        public JobLanguage Language { get; set; }

        [DisplayName("Post time")]
        public DateTime PostTime { get; set; }
    }
}
