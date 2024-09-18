using System;
using System.Collections.Generic;
using System.Globalization;
using ProjectModel = CliProjectManager.Models.Project;

class Program
{
    static List<ProjectModel> projectList = new List<ProjectModel>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Project Manager ---");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. View Projects");
            Console.WriteLine("3. Search Projects");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine(choice);

            ProjectModel newProject = new ProjectModel();
            switch(choice)
            {
                case "1":
                    newProject.CreateProject();
                    break;
                case "2":
                    //newProject.ViewProjects();
                    break;
                case "3":
                    //newProject.SearchProjects();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("\nWrong input, please try again by choosing one of the numbers listed bellow.");
                    break;
            }
        }
    }
}