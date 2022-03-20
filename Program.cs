using System;

namespace CodingTracker
{
    class Program
    {
        static void Main()
        {
            
            // Test Coding Session
            while (true)
            {
                Console.Out.WriteLine("Press enter to start coding session");
                Console.ReadLine();
                var session = new CodingSession();
                session.StartSession();

                Console.Out.WriteLine("Press enter to end coding session");
                Console.ReadLine();
                session.StopSession();

                var duration = session.GetDuration();
                Console.Out.WriteLine(
                    $"Session time:  Hours: {duration.Hours}, Minutes: {duration.Minutes}, Seconds: {duration.Seconds}");
                Console.Out.WriteLine("Session Id" + session.Id);
                break;
            }

            // ### ConsoleTableExt Example ###
            // 
            // var tableData = new List<List<object>>
            // {
            //     new() {"Sakura Yammamoto", "Support Engineer", "London", 46},
            //     new() { "Serge Baldwin", "Data Coordinator", "San Francisco", 28, "something else"},
            //     new() { "Shad Decker", "Regional Director", "Edinburgh"}
            // };
            //
            // ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();
        }
    }
}