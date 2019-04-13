using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class CourseAssignmentManager
    {
        public static void CreateCourseAssignment(int CourseID, int AssignmentId)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(CourseID);
                Assignment assignment = db.Assignments.Find(AssignmentId);
                CourseAssignment courseAssignment = new CourseAssignment()
                {
                    Course = course,
                    Assignment = assignment
                };
                db.CourseAssignments.Add(courseAssignment);
                db.SaveChanges();
            }
        }

        public static void GetAssignmentsPerCourse(int courseID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                var assignments = db.CourseAssignments.Where(x => x.CourseId == courseID).ToList();
                foreach(var ass in assignments)
                {
                    Console.WriteLine($"Assignment id is {ass.AssignmentId} for the course with id: {courseID}");
                }
            }
        }

        public static void DeleteAssignmentPerCourse(int courseId, int assignmentId)
        {
            using(SchoolContext db = new SchoolContext())
            {
                CourseAssignment courseAssignment = db.CourseAssignments.Find(courseId, assignmentId);
                db.CourseAssignments.Remove(courseAssignment);
                db.SaveChanges();
            }
        }

        public static void UpdateAssignmentCourse(int courseID, int assignmentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                CourseAssignment courseAssignment = db.CourseAssignments.Find(courseID, assignmentID);
                courseAssignment.AssignmentId = assignmentID;
                db.SaveChanges();
            }
        }
        
    }
}
