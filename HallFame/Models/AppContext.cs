using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Models
{
    public class AppContext : DbContext
    {
       
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Настройка соединения
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb; Database = HallFame; Trusted_Connection =True");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        /// <summary>
        /// Установка первичного ключа для таблицы Skill и заполнение таблиц данными
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasKey("PersonId", "Name");

            modelBuilder.Entity<Person>().HasData
            (
                new Person { Id = 1, DisplayName = "Alex", Name = "Alexey"},
                new Person { Id = 2, DisplayName = "Lera", Name = "Valeria" },
                new Person { Id = 3, DisplayName = "Olya", Name = "Olga" }
            );

            modelBuilder.Entity<Skill>().HasData
            (
                new { Name = "WPF", PersonId = (long)2, Level = (byte)2 },
                new { Name = "C#", PersonId = (long)3, Level = (byte)5 },
                new { Name = "Data Science", PersonId = (long)4, Level = (byte)10 },
                new { Name = "SQL",  PersonId = (long)5,  Level = (byte)11}

            );
        }





    }
}
