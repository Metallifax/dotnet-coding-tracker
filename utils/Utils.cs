#nullable enable
using System;
using System.Collections.Generic;
using ConsoleTableExt;
using static CodingTracker.controller.CodingSessionsController;

namespace CodingTracker.utils
{
    public static class Utils
    {
        private const string Title = "~* Welcome to Coding Tracker *~";

        private const string Menu = "\n~ Main Menu ~\nPlease select an activity:\n1. View your coding sessions\n" +
                                    "2. Start a session\n3. Quit";

        public static void AppLoop()
        {
            Print(Title);
            while (true)
            {
                try
                {
                    Print(Menu);
                    var choice = PromptForInput("Your choice: ");

                    switch (Convert.ToInt32(choice))
                    {
                        case 1:
                            ReadCodingSessions();
                            break;
                        case 2:
                            RecordACodingSession();
                            break;
                        case 3:
                            Print("Goodbye!");
                            return;
                        default:
                            Print("Could not understand!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Print(ReturnError(e));
                }
            }
        }

        public static string? PromptForInput(string message)
        {
            Console.Out.Write(message);
            return Console.ReadLine();
        }

        public static string ReturnError(Exception exception)
        {
            return "Oops.... Something went wrong!: " + exception.Message;
        }

        public static void Print(string? message = null)
        {
            Console.Out.WriteLine(message);
        }

        public static bool NameAndTimeIsInvalid(string? habitName, string? habitTime)
        {
            if (string.IsNullOrEmpty(habitName))
            {
                Print("Habit name must not be empty");
                return true;
            }

            if (string.IsNullOrEmpty(habitTime))
            {
                Print("Habit time value must not be empty");
                return true;
            }

            if (Convert.ToInt32(habitTime) <= 0)
            {
                Print("Habit time must be greater than 0");
                return true;
            }

            return false;
        }

        public static void DisplayListAsTable(List<List<object>> list)
        {
            ConsoleTableBuilder
                .From(list)
                .WithTitle("Your Coding Sessions")
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }
    }
}
