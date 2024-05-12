using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SearchSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Database
{
    internal class ConcreteDbSet<T> : DbSet<T> where T : class
    {
        public override IEntityType EntityType => throw new NotImplementedException();

        public List<T> ToList()
        {
            using (var context = new DatabaseContext())
            {
                ConcreteDbSet<T> currentDbSet = (ConcreteDbSet<T>) context.Records;
                IQueryable<T> query = context.Set<T>();

                return query.ToList();
            }
        }
    }
}
