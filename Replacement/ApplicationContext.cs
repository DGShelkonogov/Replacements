using Microsoft.EntityFrameworkCore;
using Replacement.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Annotation = System.ComponentModel.DataAnnotations;
using System;

namespace Replacement
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lession> Lessions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ReplacementEvent> Replacements { get; set; }
        public DbSet<Request> Requests { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Replacement;Username=postgres;Password=123");
        }

        public static bool validData(Object args)
        {
            var results = new List<Annotation.ValidationResult>();
            var context = new ValidationContext(args);
            if (!Validator.TryValidateObject(args, context, results, true))
            {
                string message = "";
                foreach (var error in results)
                {
                    message += error.ErrorMessage + '\n';
                }
                //MessageBox.Show(message);
                return false;
            }
            return true;
        }
    }
}
