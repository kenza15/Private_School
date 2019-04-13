using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class CourseManager
    {
        static public void CreateCourse(string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            Course course = new Course()
            {
                Title = title,
                Stream = stream,
                Type = type,
                StartDate = startDate,
                EndDate = endDate
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public static void CourseSchedule(int courseId,DateTime startDate, DateTime endDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(courseId);
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }
        }

        static public void CreateCourse(int id, string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            Course course = new Course()
            {
                Id = id,
                Title = title,
                Stream = stream,
                Type = type,
                StartDate = startDate,
                EndDate = endDate
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        static public List<Course> GetAllCourses()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Courses.ToList();
            }
        }

        static public void DeleteCourse(int id)
        {
            using(SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if(course == null) { return; }
                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }

        

        static public void UpdateCourse(int oldId, string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(oldId);
                course.Title = title;
                course.Stream = stream;
                course.Type = type;
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }
        }

        
    }
}
