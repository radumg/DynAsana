﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            var asanaClient = new Asana.Client("Bearer 0/7e47c745e9546e47b4f677926649db7d");
            Console.WriteLine("Created a new Asana client ========");
            Console.WriteLine("Token : " + asanaClient.Token);
            Console.WriteLine("BaseUrl : " + asanaClient.BaseUrl);
            Console.WriteLine();

            // GET the current user from Asana
            Console.WriteLine("Current user ======================");
            var user = asanaClient.GetCurrentUser();
            Console.WriteLine("Id   : " + user.Id);
            Console.WriteLine("Name : " + user.Name);
            Console.WriteLine("Id   : " + user.Email);
            Console.Write("Workspaces : "); user.Workspaces.ForEach(w => Console.Write(w.Name + ", "));
            Console.WriteLine();

            // GET a task from Asana
            Console.WriteLine("GET a task from Asana =============");
            var task = asanaClient.GetTask("314317576360056");
            //Dump(task);
            Console.WriteLine();

            // Access deserialised properties
            Console.WriteLine("Deserialised task =================");
            Console.WriteLine("Id   : " + task.Id);
            Console.WriteLine("Name : " + task.Name);
            Console.Write("Tags : "); task.Tags.ForEach(t => Console.Write(t.Name + ", "));
            Console.WriteLine();
            Console.WriteLine("Description : " + task.Notes.Substring(0, 50));

            // POST a task to Asana
            Console.WriteLine();
            Console.WriteLine("POST a task to Asana ==============");
            var nt = newTask();
            var createdTask = asanaClient.CreateTask(nt);
            Console.WriteLine("Id   : " + createdTask.Id);
            Console.WriteLine("Name : " + createdTask.Name);
            Console.Write("Tags : "); task.Tags.ForEach(t => Console.Write(t.Name + ", "));
            Console.WriteLine();

            // wait before closing the window
            Console.WriteLine("Press any key to exit now...");
            Console.ReadKey();
        }

        internal static Asana.Task newTask()
        {
            var uploadTask = new Task();
            var proj = new Project() { Id = "200419949000730", Name = "software dev" };
            var projList = new List<Project>();
            projList.Add(proj);
            uploadTask.Projects = projList;
            uploadTask.Workspace = new Workspace() { Id = "198488041683503" };
            uploadTask.Assignee = new User() { Id = "198487209472854" };
            uploadTask.Name = "New task created at " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            uploadTask.Notes = "This is a task created from the API.";
            var tag = new Tag() { Id = "204494482735923" };
            var tagList = new List<Tag>();
            tagList.Add(tag);
            uploadTask.Tags = tagList;
            return uploadTask;
        }

        public static void Dump(object obj)
        {
            Console.WriteLine("~~~~~~ "+ obj.ToString() + "~~~~~~ ");
            Console.WriteLine(JObject.FromObject(obj).ToString());
            Console.WriteLine("~~~~~~~~~~~~~ ");
        }



    }
}