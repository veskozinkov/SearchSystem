using SearchSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Database
{
    internal static class DatabaseJobsHelper
    {
        public static Job AddJob(Job job)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                Job addedJob = context.Add(job).Entity;
                context.SaveChanges();

                return addedJob;
            }
        }

        public static List<Job> GetAllJobs()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                return context.Jobs.ToList();
            }
        }

        public static Job? GetJobById(int Id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                return context.Jobs.FirstOrDefault(x => x.Id == Id);
            }
        }
    }
}
