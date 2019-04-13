using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;
namespace MySchool
{
    public static class TrainerAssignmentManager
    {
        static public void CreateTrainerAssignment(int trainerID, int assignmentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Assignment assignment = db.Assignments.Find(assignmentID);
                TrainerAssignment trainerAssignment = new TrainerAssignment()
                {
                    Trainer = trainer,
                    Assignment = assignment

                };
                db.TrainerAssignments.Add(trainerAssignment);
                db.SaveChanges();
            }
        }
    }
}
