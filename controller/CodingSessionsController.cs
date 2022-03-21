using System;
using System.Collections.Generic;
using CodingTracker.model;
using static CodingTracker.utils.DbUtils;
using static CodingTracker.utils.TableUtils;
using static CodingTracker.utils.Utils;

namespace CodingTracker.controller
{
    public static class CodingSessionsController
    {
        public static void ReadCodingSessions()
        {
            using var conn = GenerateConnection();
            using var cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM Coding_Session";
                var reader = cmd.ExecuteReader();
                var sessionList = new List<List<object>>();

                while (reader.Read())
                {
                    var duration = TimeSpan.FromSeconds(reader.GetFloat(3));

                    sessionList.Add(new List<object>
                    {
                        reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), duration.Hours,
                        duration.Minutes, duration.Seconds, duration
                    });
                }

                Print();
                DisplaySessionsAsTable(sessionList);
                DisplayTotalCodingTimeAsTable(sessionList);
            }
            catch (Exception e)
            {
                Print(ReturnError(e));
            }
        }

        public static void RecordACodingSession()
        {
            try
            {
                while (true)
                {
                    var choice =
                        PromptForInput(
                            "\nAre you sure you would like to begin a coding session?" +
                            "\n1. Yes\n2. No\nYour choice: ");

                    if (string.IsNullOrEmpty(choice))
                    {
                        Print("Choice cannot be empty");
                    }

                    if (Convert.ToInt32(choice) == 1)
                    {
                        break;
                    }

                    if (Convert.ToInt32(choice) == 2)
                    {
                        return;
                    }

                    Print("Could not understand!");
                }

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
                    break;
                }
            }
            catch (Exception e)
            {
                Print(ReturnError(e));
            }
        }
    }
}