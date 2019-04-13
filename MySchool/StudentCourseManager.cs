using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class StudentCourseManager
    {
        static public void CreateStudentCourse(int studentID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Course course = db.Courses.Find(courseID);
                if (student!=null || course!=null)
                {
                    return;
                }
                StudentCourse studentCourse = new StudentCourse()
                {
                    Student = student,
                    Course = course
                    
                };
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
            }
        }

        static public void GetStudentsPerCourse(int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var students = db.StudentCourses.Where(x => x.CourseId == courseID).ToList();
                foreach (var st in students)
                {
                    Console.WriteLine($"Student id who is enrolled is: {st.StudentId}");
                }
            }
        }

        static public void GetCoursesPerStudent(int studentID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                var courses = db.StudentCourses.Where(x => x.StudentId == studentID).ToList();
                foreach (var c in courses)
                {
                    Console.WriteLine(c);
                }
            }
        }

        static public void GetCoursesPerStudentWithDate(int studentId, DateTime yourDate)
        {
            using(SchoolContext db = new SchoolContext())
            {
                var courses = db.StudentCourses.Where(x => (x.Course.StartDate < yourDate && yourDate< x.Course.EndDate));
                foreach (var c in courses)
                {
                    Console.WriteLine(c);
                }
            }
        }

        static public void DeleteStudentPerCourse(int studentID,int courseID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                StudentCourse student = db.StudentCourses.Find(studentID,courseID);

                db.StudentCourses.Remove(student);
                db.SaveChanges();
            }
        }

        public static void UpdateStudentCourse(int studentID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                StudentCourse studentCourse = db.StudentCourses.Find(studentID, courseID);
                studentCourse.CourseId= courseID;
                db.SaveChanges();
            }
        }
    }
}
