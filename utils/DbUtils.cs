using System;
using System.Data.SQLite;
using System.IO;
using CodingTracker.model;
using static CodingTracker.utils.Utils;

namespace CodingTracker.utils
{
    public class DbUtils
    {
        private const string DbPath = "./data/database.db";

        public static SQLiteConnection GenerateConnection()
        {
            SQLiteConnection conn;

            if (File.Exists(DbPath))
            {
                conn = new SQLiteConnection($"Data Source={DbPath}");
                conn.Open();

                return conn;
            }

            conn = new SQLiteConnection($"Data Source={DbPath};New=True;Compress=True");
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"create table Coding_Session (
                                    ID          INTEGER
                                        constraint ID
                                            primary key autoincrement,
                                    Start_Time  DATE,
                                    End_Time    DATE,
                                    Duration    INTEGER   
                                );";
            cmd.ExecuteNonQuery();

            return conn;
        }

        public void RecordACodingSession()
        {
            while (true)
            {
                Print("Press enter to start coding session");
                Console.ReadLine();
                var session = new CodingSession();
                session.StartSession();

                Print("Press enter to end coding session");
                Console.ReadLine();
                session.StopSession();

                var duration = session.GetDuration();
                Print(
                    $"Session time:  Hours: {duration.Hours}, Minutes: {duration.Minutes}, Seconds: {duration.Seconds}");
                Print("Session Id" + session.Id);
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