using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_of_SL.Models;

namespace University_of_SL.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Course>().ToTable("Course");
            modelbuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelbuilder.Entity<Student>().ToTable("Student");
            modelbuilder.Entity<Department>().ToTable("Department");
            modelbuilder.Entity<Instructor>().ToTable("Instructor");
            modelbuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelbuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            modelbuilder.Entity<CourseAssignment>().HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}
