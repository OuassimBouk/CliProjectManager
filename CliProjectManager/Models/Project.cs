using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CliProjectManager.Models
{
    internal class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Project CreateProject()
        {
            // Create a new project by reading input
            Console.WriteLine("\nWhat should your project be called?");
            Title = Console.ReadLine();
            Console.WriteLine("\nTell us more about your project.");
            Description = Console.ReadLine();

            // Get the path to the Data folder in the project root
            string folderPath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data");

            // Create the 'Data' folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Define the full path to the Projects.json file
            string filePath = Path.Combine(folderPath, "Projects.json");

            // Create a list to hold all the projects
            List<Project> projects = new List<Project>();

            // Check if the file already exists and has data
            if (File.Exists(filePath))
            {
                // Read existing JSON data
                string existingData = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(existingData))
                {
                    // Deserialize the existing data to a list of projects
                    projects = JsonSerializer.Deserialize<List<Project>>(existingData);
                }
            }

            // Add the newly created project to the list
            projects.Add(this);  // `this` refers to the current `Project` object

            // Serialize the updated list of projects to JSON
            string jsonString = JsonSerializer.Serialize(projects, new JsonSerializerOptions { WriteIndented = true });

            // Write the updated JSON to the Projects.json file
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine("Project saved successfully.");
            return this;  // Returning the current `Project` object
        }
    }
}
