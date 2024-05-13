using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchSystem.Others.Enums.Job;
using System.ComponentModel;
using SearchSystem.Others.Attributes;

namespace SearchSystem.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        [Filterable(false)]
        public int Id { get; set; }

        [DisplayName("City")]
        [Filterable(true)]
        public JobCity City { get; set; }

        [DisplayName("Category")]
        [Filterable(true)]
        public JobCategory Category { get; set; }

        [DisplayName("Employment")]
        [Filterable(true)]
        public JobEmployment Employment { get; set; }

        [DisplayName("Without experience")]
        [Filterable(true)]
        public bool WithoutExperience { get; set; }

        [DisplayName("Remote interview")]
        [Filterable(true)]
        public bool RemoteInterview { get; set; }

        [DisplayName("Workplace")]
        [Filterable(true)]
        public JobWorkplace Workplace { get; set; }

        [DisplayName("Position")]
        [Filterable(true)]
        public JobPosition Position { get; set; }

        [DisplayName("Provider")]
        [Filterable(true)]
        public JobProvider Provider { get; set; }

        [DisplayName("Salary")]
        [Filterable(true)]
        public int Salary { get; set; }

        [DisplayName("Paid leave")]
        [Filterable(true)]
        public JobPaidLeave PaidLeave { get; set; }

        [DisplayName("Language")]
        [Filterable(true)]
        public JobLanguage Language { get; set; }

        [DisplayName("Post time")]
        [Filterable(true)]
        public DateTime PostTime { get; set; }
    }
}
