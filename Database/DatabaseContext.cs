using System.IO;
using Microsoft.EntityFrameworkCore;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;

namespace SearchSystem.Database
{
    internal class DatabaseContext : DbContext
    {
        public static Type ModelType { get; set; } = typeof(Job);

        public dynamic Records { get; set; }

        public DatabaseContext()
        {
            Type genericType = typeof(ConcreteDbSet<>).MakeGenericType(ModelType);
            Records = Activator.CreateInstance(genericType)!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = ModelType.Name + ".db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity(ModelType);
            var idProperty = entityBuilder.Property("Id");

            idProperty.ValueGeneratedOnAdd();

            /*List<object> records = RandomModelGenerator.GenerateRandomObjects(ModelType, 100);

            foreach (object record in records)
            {
                entityBuilder.HasData(record);
            }*/
        }
    }
}
