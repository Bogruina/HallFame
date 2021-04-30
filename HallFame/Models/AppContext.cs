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
                "Server=(localdb)\\mssqllocaldb; Database = HallFame;");
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
                new Person { DisplayName = "Alex", Name = "Alexey",Id = 1 },
                new Person { DisplayName = "Lera", Name = "Valeria", Id = 2 },
                new Person { DisplayName = "Olya", Name = "Olga", Id =3 }
            );

            modelBuilder.Entity<Skill>().HasData
            (
                new Skill { Name = "WPF", PersonId = (long)1, Level = (byte)2 },
                new Skill { Name = "C#", PersonId = (long)2, Level = (byte)5 },
                new Skill { Name = "Data Science", PersonId = (long)3, Level = (byte)5 },
                new Skill { Name = "SQL",  PersonId = (long)5,  Level = (byte)1 }

            );
        }





    }
}
