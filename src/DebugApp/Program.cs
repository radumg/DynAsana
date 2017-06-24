using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Asana;
using System.IO;
using System.Xml;
using Asana.Classes;

/// <summary>
/// Namespace used to host classes and methods used during debugging only, in the absence of proper unit tests
/// Set the solution default startup to this project to enable quick debugging in Visual Studio.
/// </summary>
namespace Asana
{
    class Program
    {
        private static void Main(string[] args)
        {
            // build a new Slack client object
            Asana.Authentication.GetKeyFromXMLFile(Asana.Authentication.DefaultXMLPath);
            var asanaClient = new Asana.Client(Asana.Authentication.APIKEY);
            Console.WriteLine("Created a new Asana client ========");
            Console.WriteLine("Token : " + asanaClient.Token);
            Console.WriteLine("BaseUrl : " + asanaClient.BaseUrl);
            Console.WriteLine();

            // GET the current user from Asana
            Console.WriteLine("Current user ======================");
            var user = asanaClient.GetUserBySession();
            Console.WriteLine("Id   : " + user.Id);
            Console.WriteLine("Name : " + user.Name);
            Console.WriteLine("Id   : " + user.Email);
            Console.Write("Workspaces : "); user.Workspaces.ForEach(w => Console.Write(w.Name + ", "));
            Console.WriteLine();
            Console.WriteLine();

            // GET a task from Asana
            Console.WriteLine("GET a task from Asana =============");
            var task = asanaClient.GetTaskById("314317576360056");
            // Access deserialised properties
            Console.WriteLine("Id   : " + task.Id);
            Console.WriteLine("Name : " + task.Name);
            Console.Write("Tags : "); task.Tags.ForEach(t => Console.Write(t.Name + ", "));
            Console.WriteLine();
            Console.WriteLine("Description : " + task.Notes.Substring(0, 50));

            // POST a task to Asana
            Console.WriteLine();
            Console.WriteLine("POST a task to Asana ==============");
            var nt = newTask();
            try
            {
                var createdTask = asanaClient.CreateTask(nt);
                Console.WriteLine("Id   : " + createdTask.Id);
                Console.WriteLine("Name : " + createdTask.Name);
                Console.Write("Projects : "); createdTask.Projects.ForEach(p => Console.Write(p.Name + ", ")); Console.WriteLine();
                Console.Write("Tags : "); createdTask.Tags.ForEach(t => Console.Write(t.Name + ", ")); Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Could not POST to Asana, error : ==============");
                Console.WriteLine(e.Message);
                throw;
            }

            // wait before closing the window
            Console.WriteLine("Press any key to exit now...");
            Console.ReadKey();
        }

        internal static Task newTask()
        {
            // workspace & projects
            var Workspace = new Workspace("198488041683503"); // grimshaw.global
            var projList = new List<Project>();
            projList.Add(new Project("200419949000730")); // BIM | Development
            projList.Add(new Project("207845234365369")); // BIM | Management);

            var Assignee = new User("198487209472854"); // radu.gidei

            // Name & description
            var TaskName = "New task created at " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            var Notes = "This is a task created from the API." + Environment.NewLine +
                "It belongs to 2 separate projects (software dev & bim general)." + Environment.NewLine +
                "It also has 2 tags (Dyn, Konrad)";

            // tags
            var tagList = new List<Tag>();
            tagList.Add(new Tag("204494482735923")); // DYN);
            tagList.Add(new Tag("198900482693477")); // Konrad);

            // make the task
            var uploadTask = new Task();
            uploadTask = TaskByExtendedProperties(TaskName, Notes, Workspace, Assignee, projList, tagList);

            Console.WriteLine();
            Console.WriteLine("Created a task to post to Asana ==============");
            Dump(uploadTask);

            return uploadTask;
        }

        public static void Dump(object obj)
        {
            Console.WriteLine("~~~~~~ " + obj.ToString() + "~~~~~~ ");
            Console.WriteLine(JObject.FromObject(obj).ToString());
            Console.WriteLine("~~~~~~~~~~~~~ ");
        }



    }
}
