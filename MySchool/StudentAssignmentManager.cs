using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class StudentAssignmentManager
    {
        static public void CreateStudentAssignment(int studentID, int assignmentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Assignment assignment = db.Assignments.Find(assignmentID);
                StudentAssignment studentAssignment = new StudentAssignment()
                {
                    Student = student,
                    Assignment = assignment

                };
                db.StudentAssignments.Add(studentAssignment);
                db.SaveChanges();
            }
        }

        static public void GetAllStudentsPerAssignment(int assignmentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment= db.Assignments.Find(assignmentID);
                List<Student> st = assignment.Students.ToList();
                foreach (var s in st)
                {
                    Console.WriteLine(s);
                }
            }
        }

        static public void GetAllAssignmentsPerStudent(int studentID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                List<Assignment> ass = student.Assignments.ToList();
                foreach(var a in ass)
                {
                    Console.WriteLine(a);
                }
            }
        }

        public static void SubmitAnAssignment(int studentId, int assignmentId)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentId);
                Assignment assignment = db.Assignments.Find(assignmentId);
                StudentAssignment studentAssignment = db.StudentAssignments.Find(studentId, assignmentId);
                studentAssignment.IsSubmitted = true;
            }
        }

        public static void DaysUntillSubmission(int studentId)
        {
            using (SchoolContext db = new SchoolContext())
            {

                var assignments = db.StudentAssignments.Where(x => x.StudentId == studentId).ToList();
                foreach (var ass in assignments)
                {
                    if (DateTime.Now < ass.Assignment.Submission)
                    {
                        Console.WriteLine($"You have {(DateTime.Now - ass.Assignment.Submission).Days} days for " +
                            $"assignment with id: {ass.Assignment.Id} and title: {ass.Assignment.Title}");
                    }
                }
            }
        }


    }
}
