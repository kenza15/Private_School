using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "My School";
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            using(SchoolContext db = new SchoolContext())
            {
                if (UserManager.getCountOfUsers() < 1)
                {
                    UserManager.CreateUser("admin", SecurePasswordHasher.Hash("admin"));
                }
                
            }
            Console.WriteLine("You want to login in as a Student(1), Trainer(2) or Head Master(3)?");
            string ch = Console.ReadLine();
            while (true)
            {


                if (ch == "3")
                {
                    
                    Menu.MainMenuHeadMaster();
                }
                else if (ch == "2")
                {
                    Menu.MainMenuTrainer();
                }
                else if (ch == "1")
                {
                    Menu.MainMenuStudent();
                }
                else
                {
                    Console.WriteLine("Invalid input. Choose between 1,2 or 3.");
                    ch = Console.ReadLine();
                }
            }
        }

    }
}