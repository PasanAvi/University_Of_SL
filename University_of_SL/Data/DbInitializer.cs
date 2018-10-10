using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_of_SL.Models;

namespace University_of_SL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            //Look for any students
            if (context.Students.Any())
            {
                return;    // DB has been seeded.
            }
            List<Student> students = new List<Student>() {
                new Student(){Firstname = "Pasan", Lastname = "Avishka", EnrollmentDate = DateTime.Parse("2005-01-01")},
                new Student(){Firstname = "Kavindu", Lastname = "Sandeepa", EnrollmentDate = DateTime.Parse("2005-01-03")},
                new Student(){Firstname = "Shown", Lastname = "Micheals", EnrollmentDate = DateTime.Parse("2005-01-03")},
                new Student(){Firstname = "John", Lastname = "Cena", EnrollmentDate = DateTime.Parse("2005-01-05")},
                new Student(){Firstname = "Saman", Lastname = "kumara", EnrollmentDate = DateTime.Parse("2006-01-01")},
                new Student(){Firstname = "Josaph", Lastname = "Corray", EnrollmentDate = DateTime.Parse("2006-01-02")},
                new Student(){Firstname = "Mary", Lastname = "Stevanson", EnrollmentDate = DateTime.Parse("2008-01-01")},
                new Student(){Firstname = "Diane", Lastname = "Angeline", EnrollmentDate = DateTime.Parse("2008-01-10")},
            };
            foreach (var s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            List<Instructor> instructors = new List<Instructor>()
            {
                new Instructor(){FirstMidName = "Sunil", LastName = "Perera", HireDate = DateTime.Parse("2004-02-12") },
                new Instructor(){FirstMidName = "Jagath", LastName = "Chandana", HireDate = DateTime.Parse("2012-01-22") },
                new Instructor(){FirstMidName = "Kamal", LastName = "Karunaratna", HireDate = DateTime.Parse("2006-10-12") },
                new Instructor(){FirstMidName = "Arawinda", LastName = "Kumara", HireDate = DateTime.Parse("2004-08-11") },
                new Instructor(){FirstMidName = "Nimal", LastName = "weerasinghe", HireDate = DateTime.Parse("2004-05-19") }
            };
            foreach (var i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            List<Department> departments = new List<Department>()
            {
                new Department(){ Name="English", Budget = 350000, StartDate = DateTime.Parse("2007-07-09"),
                                  InstructorID = instructors.Single(i => i.LastName == "Kumara").ID  },
                new Department(){ Name="Mathmatics", Budget = 100000, StartDate = DateTime.Parse("2007-07-09"),
                                  InstructorID = instructors.Single(i => i.LastName == "Chandana").ID  },
                new Department(){ Name="Engineering", Budget = 350000, StartDate = DateTime.Parse("2008-10-09"),
                                  InstructorID = instructors.Single(i => i.LastName == "Weerasinghe").ID  },
                new Department(){ Name="Economics", Budget = 100000, StartDate = DateTime.Parse("2007-11-01"),
                                  InstructorID = instructors.Single(i => i.LastName == "Perera").ID  },
            };
            foreach (var d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            List<Course> courses = new List<Course>()
            {
                 new Course{CourseID=1050,Title="Chemistry",Credits=3,
                                departmentID = departments.Single(d => d.Name == "Engineering").DepartmentID},
                 new Course{CourseID=40,Title="Microeconomics",Credits=3,
                                departmentID = departments.Single(d => d.Name == "Economics").DepartmentID},
                 new Course{CourseID=41,Title="Macroeconomics",Credits=3,
                                departmentID = departments.Single(d => d.Name == "Economics").DepartmentID},
                 new Course{CourseID=14,Title="Calculus",Credits=4,
                                departmentID = departments.Single(d => d.Name == "Mathmatics").DepartmentID},
                 new Course{CourseID=31,Title="Trigonometry",Credits=4,
                                departmentID = departments.Single(d => d.Name == "Mathmatics").DepartmentID},
                 new Course{CourseID=20,Title="Composition",Credits=3,
                                departmentID = departments.Single(d => d.Name == "English").DepartmentID},
                 new Course{CourseID=42,Title="Literature",Credits=4,
                                departmentID = departments.Single(d => d.Name == "English").DepartmentID}
            };
            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            List<OfficeAssignment> officeasignments = new List<OfficeAssignment>()
            {
                new OfficeAssignment(){ InstructorID = instructors.Single(i => i.LastName == "Perera").ID,Location = "Street 025"},
                new OfficeAssignment(){ InstructorID = instructors.Single(i => i.LastName == "Chandana").ID,Location = "Main 025"},
                new OfficeAssignment(){ InstructorID = instructors.Single(i => i.LastName == "Kumara").ID,Location = "Street 025"}
            };
            foreach (var o in officeasignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            List<CourseAssignment> CourseInstructors = new List<CourseAssignment>()
            {
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Weerasinghe").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Chandana").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Weerasinghe").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Weerasinghe").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Calculus").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Chandana").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Trigonometry").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Weerasinghe").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Kumara").ID},
                new CourseAssignment(){CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                                        InstructorID = instructors.Single(i => i.LastName == "Kumara").ID},
            };
            foreach (var c in CourseInstructors)
            {
                context.CourseAssignments.Add(c);
            }
            context.SaveChanges();


            List<Enrollment> enrollments = new List<Enrollment>()
            {
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Avishka").ID,
                                CourseID =courses.Single(c => c.Title == "Chemestry").CourseID,Grade=Grade.A},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Avishka").ID,
                                CourseID =courses.Single(c => c.Title == "Microeconomics").CourseID,Grade=Grade.C},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Avishka").ID,
                                CourseID = courses.Single(c => c.Title == "Chemestry").CourseID,Grade=Grade.B},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Sandeepa").ID,
                                CourseID =courses.Single(c => c.Title == "Calculas").CourseID,Grade=Grade.B},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Kumara").ID,
                                CourseID =courses.Single(c => c.Title == "Trigonometry").CourseID,Grade=Grade.F},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Avishka").ID,
                                CourseID =courses.Single(c => c.Title == "Composition").CourseID,Grade=Grade.F},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Kumara").ID,
                                CourseID =courses.Single(c => c.Title == "Chemestry").CourseID},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Sandeepa").ID,
                                CourseID =courses.Single(c => c.Title == "Chemestry").CourseID},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Avishka").ID,
                                CourseID =courses.Single(c => c.Title == "Microeconoics").CourseID,Grade=Grade.F},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Cena").ID,
                                CourseID =courses.Single(c => c.Title == "Chemestry").CourseID,Grade=Grade.C},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Corray").ID,
                                CourseID =courses.Single(c => c.Title == "Composition").CourseID},
                new Enrollment{StudentID=students.Single(s => s.Lastname == "Cena").ID,
                                CourseID =courses.Single(c => c.Title == "Chemestry").CourseID,Grade=Grade.A},
            };
            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }


    }
}
