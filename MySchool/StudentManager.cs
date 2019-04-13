using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class StudentManager
    {
        static public void CreateStudent(string username, string password, string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
                    Student st = new Student()
                    {
                        Username = username,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        TuitionFees = tuitionFees
                    };
                    using (SchoolContext db = new SchoolContext())
                    {
                    db.Students.Add(st);
                    db.SaveChanges();
                    }
                
            
        }

        static public void CreateStudent(int id,string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            Student st = new Student()
            {
                Id=id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                TuitionFees = tuitionFees
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Students.Add(st);
                db.SaveChanges();
            }


        }

        static public List<Student> GetAllStudents()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Students.OrderBy(x => x.LastName).OrderBy(y => y.FirstName).ToList();
            }
        }

        static public void DeleteStudent(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student st = db.Students.Find(id);
                if (st == null)
                {
                    return;
                }
                db.Students.Remove(st);
                db.SaveChanges();
            }
        }

        static public Student GetStudentByUserId(int id)
        {
                using(SchoolContext db = new SchoolContext())
            {
                return db.Students.Find(id);
            }
        }

        
            public static void UpdateStudent(int id, string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
            {
                using (SchoolContext db = new SchoolContext())
                {
                    Student student = db.Students.Find(id);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.DateOfBirth = dateOfBirth;
                    student.TuitionFees = tuitionFees;
                    db.SaveChanges();
                }
            }


        public static Student ValidateLogIn(string username, string password)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var query = db.Students.Where(t => t.Username == username).Where(t => t.Password == password).FirstOrDefault<Student>();
                return query;
                
            }
        }

        public static Student FindPassword(string username)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var query = db.Students.Where(s => s.Username == username).FirstOrDefault<Student>();
                return query;
            }
        }
    }
}
