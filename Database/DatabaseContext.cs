using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchSystem.Models;
using SearchSystem.Others.JobEnums;

namespace SearchSystem.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Jobs.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().Property(e => e.Id).ValueGeneratedOnAdd();

            var job1 = new Job
            {
                Id = -1,
                City = JobCity.SOFIA,
                Category = JobCategory.TRADE_SALES,
                Employment = JobEmployment.FULL_TIME,
                WithoutExperience = false,
                RemoteInterview = true,
                Workplaces = new List<JobWorkplace> { JobWorkplace.OFFICE },
                Position = JobPosition.EXPERT_SPECIALIST,
                Provider = JobProvider.EMPLOYER,
                Salary = 5000,
                PaidLeave = 25,
                Languages = new List<JobLanguage> { JobLanguage.ENGLISH, JobLanguage.GERMAN },
                PostTime = DateTime.Now.AddDays(-10)
            };
            modelBuilder.Entity<Job>().HasData(job1);

            var job2 = new Job
            {
                Id = -2,
                City = JobCity.VARNA,
                Category = JobCategory.RESTAURANTS_HOTELS_TOURISM,
                Employment = JobEmployment.PART_TIME,
                WithoutExperience = true,
                RemoteInterview = false,
                Workplaces = new List<JobWorkplace> { JobWorkplace.HYBRID },
                Position = JobPosition.EMPLOYEE_WORKER,
                Provider = JobProvider.AGENCIES,
                Salary = 2500,
                PaidLeave = 20,
                Languages = new List<JobLanguage> { JobLanguage.BULGARIAN, JobLanguage.ENGLISH },
                PostTime = DateTime.Now.AddDays(-15)
            };
            modelBuilder.Entity<Job>().HasData(job2);

            var job3 = new Job
            {
                Id= -3,
                City = JobCity.PLOVDIV,
                Category = JobCategory.PRODUCTION,
                Employment = JobEmployment.FULL_TIME,
                WithoutExperience = false,
                RemoteInterview = false,
                Workplaces = new List<JobWorkplace> { JobWorkplace.OFFICE },
                Position = JobPosition.MANAGEMENT,
                Provider = JobProvider.EMPLOYER,
                Salary = 8000,
                PaidLeave = 30,
                Languages = new List<JobLanguage> { JobLanguage.BULGARIAN, JobLanguage.ENGLISH },
                PostTime = DateTime.Now.AddDays(-5)
            };
            modelBuilder.Entity<Job>().HasData(job3);

            var job4 = new Job
            {
                Id = -4,
                City = JobCity.BURGAS,
                Category = JobCategory.ADMINISTRATIVE_OFFICE_BUSINESS,
                Employment = JobEmployment.FULL_TIME,
                WithoutExperience = true,
                RemoteInterview = true,
                Workplaces = new List<JobWorkplace> { JobWorkplace.HOME },
                Position = JobPosition.EXPERT_SPECIALIST,
                Provider = JobProvider.EMPLOYER,
                Salary = 5500,
                PaidLeave = 25,
                Languages = new List<JobLanguage> { JobLanguage.ENGLISH },
                PostTime = DateTime.Now.AddDays(-20)
            };
            modelBuilder.Entity<Job>().HasData(job4);

            var job5 = new Job
            {
                Id= -5,
                City = JobCity.RUSE,
                Category = JobCategory.DRIVERS_COURIERS,
                Employment = JobEmployment.FULL_TIME,
                WithoutExperience = false,
                RemoteInterview = false,
                Workplaces = new List<JobWorkplace> { JobWorkplace.OFFICE },
                Position = JobPosition.EMPLOYEE_WORKER,
                Provider = JobProvider.EMPLOYER,
                Salary = 4500,
                PaidLeave = 20,
                Languages = new List<JobLanguage> { JobLanguage.BULGARIAN },
                PostTime = DateTime.Now.AddDays(-25)
            };
            modelBuilder.Entity<Job>().HasData(job5);
        }
    }
}
