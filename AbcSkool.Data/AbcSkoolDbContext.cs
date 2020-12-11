using AbcSkool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data
{
    public class AbcSkoolDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Student> Subjects { get; set; }

        public DbSet<StudentSubjects> StudentSubjects { get; set; }


        public AbcSkoolDbContext(DbContextOptions<AbcSkoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubjects>()
                        .HasKey(record => new { record.StudentId, record.SubjectId });
        }

    }
}
