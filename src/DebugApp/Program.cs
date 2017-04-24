using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
            var asanaClient = new Asana.Client();
            Console.WriteLine("Created a new Asana client ========");
            Console.WriteLine("Token : " + asanaClient.Token);
            Console.WriteLine("BaseUrl : " + asanaClient.BaseUrl);
            Console.WriteLine();

            // GET a task from Asana
            var task = asanaClient.GetTask("314317576360056");
            Dump(task);

            // wait before closing the window
            Console.WriteLine("Press any key to exit now...");
            Console.ReadKey();
        }

        public static void Dump(object obj)
        {
            Console.WriteLine(JObject.FromObject(obj).ToString());
        }
    }
}
