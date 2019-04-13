namespace MySchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Submission = c.DateTime(nullable: false),
                        OralMark = c.Int(nullable: false),
                        TotalMark = c.Int(nullable: false),
                        Course_Id = c.Int(),
                        Trainer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Trainer_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Stream = c.String(),
                        Type = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        TuitionFees = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssignments",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AssignmentId })
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.StudentAssignments",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.AssignmentId })
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TrainerAssignments",
                c => new
                    {
                        TrainerID = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerID, t.AssignmentId })
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerID, cascadeDelete: true)
                .Index(t => t.TrainerID)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        TrainerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentAssignment1",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Assignment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Assignment_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Assignment_Id);
            
            CreateTable(
                "dbo.StudentCourse1",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.TrainerCourse1",
                c => new
                    {
                        Trainer_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_Id, t.Course_Id })
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerCourses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TrainerAssignments", "TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.TrainerAssignments", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentAssignments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.CourseAssignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssignments", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.TrainerCourse1", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourse1", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Assignments", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.StudentCourse1", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse1", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentAssignment1", "Assignment_Id", "dbo.Assignments");
            DropForeignKey("dbo.StudentAssignment1", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Assignments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.TrainerCourse1", new[] { "Course_Id" });
            DropIndex("dbo.TrainerCourse1", new[] { "Trainer_Id" });
            DropIndex("dbo.StudentCourse1", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourse1", new[] { "Student_Id" });
            DropIndex("dbo.StudentAssignment1", new[] { "Assignment_Id" });
            DropIndex("dbo.StudentAssignment1", new[] { "Student_Id" });
            DropIndex("dbo.TrainerCourses", new[] { "CourseId" });
            DropIndex("dbo.TrainerCourses", new[] { "TrainerId" });
            DropIndex("dbo.TrainerAssignments", new[] { "AssignmentId" });
            DropIndex("dbo.TrainerAssignments", new[] { "TrainerID" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentAssignments", new[] { "AssignmentId" });
            DropIndex("dbo.StudentAssignments", new[] { "StudentId" });
            DropIndex("dbo.CourseAssignments", new[] { "AssignmentId" });
            DropIndex("dbo.CourseAssignments", new[] { "CourseId" });
            DropIndex("dbo.Assignments", new[] { "Trainer_Id" });
            DropIndex("dbo.Assignments", new[] { "Course_Id" });
            DropTable("dbo.TrainerCourse1");
            DropTable("dbo.StudentCourse1");
            DropTable("dbo.StudentAssignment1");
            DropTable("dbo.Users");
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.TrainerAssignments");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.StudentAssignments");
            DropTable("dbo.CourseAssignments");
            DropTable("dbo.Trainers");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
