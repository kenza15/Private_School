using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class AssignmentManager
    {
        public static void CreateAssignment(string title, string description, DateTime submission)
        {
                Assignment ass = new Assignment()
                {
                    Title = title,
                    Description = description,
                    Submission = submission
                };
                using (SchoolContext db = new SchoolContext())
                {
                    db.Assignments.Add(ass);
                    db.SaveChanges();
                }
        }

        public static void CreateAssignment(int id, string title, string description, DateTime submission)
        {
            Assignment ass = new Assignment()
            {
                Id = id,
                Title = title,
                Description = description,
                Submission = submission
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Assignments.Add(ass);
                db.SaveChanges();
            }
        }

        public static List<Assignment> GetAllAssignments()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Assignments.OrderBy(x => x.Title).ToList();
            }
        }

        public static void DeleteAssignment(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                db.Assignments.Remove(assignment);
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int oldId, string title, string description,DateTime submission)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(oldId);
                assignment.Title = title;
                assignment.Description = description;
                assignment.Submission = submission;
                db.SaveChanges();
            }
        }
    }
}
