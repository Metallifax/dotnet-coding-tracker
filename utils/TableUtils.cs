using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConsoleTableExt;

namespace CodingTracker.utils
{
    public static class TableUtils
    {
        private static readonly Dictionary<HeaderCharMapPositions, char> FramePipCharacters = new()
        {
            {HeaderCharMapPositions.TopLeft, '╒'},
            {HeaderCharMapPositions.TopCenter, '═'},
            {HeaderCharMapPositions.TopRight, '╕'},
            {HeaderCharMapPositions.BottomLeft, '╞'},
            {HeaderCharMapPositions.BottomCenter, '╤'},
            {HeaderCharMapPositions.BottomRight, '╡'},
            {HeaderCharMapPositions.BorderTop, '═'},
            {HeaderCharMapPositions.BorderRight, '│'},
            {HeaderCharMapPositions.BorderBottom, '═'},
            {HeaderCharMapPositions.BorderLeft, '│'},
            {HeaderCharMapPositions.Divider, ' '},
        };

        public static void DisplaySessionsAsTable(List<List<object>> list)
        {
            var table = new DataTable();

            table.Columns.Add("Session ID", typeof(string));
            table.Columns.Add("Start Time", typeof(DateTime));
            table.Columns.Add("End Time", typeof(DateTime));
            table.Columns.Add("Hours", typeof(int));
            table.Columns.Add("Minutes", typeof(int));
            table.Columns.Add("Seconds", typeof(int));

            foreach (var sessionData in list)
            {
                table.Rows.Add(sessionData[0], sessionData[1], sessionData[2], sessionData[3], sessionData[4],
                    sessionData[5]);
            }

            GenerateConsoleTable("Your Coding Sessions", table);
        }

        public static void DisplayTotalCodingTimeAsTable(List<List<object>> list)
        {
            var table = new DataTable();
            var times = new List<TimeSpan>();
            var count = 0;

            table.Columns.Add("No of Sessions");
            table.Columns.Add("Hours");
            table.Columns.Add("Minutes");
            table.Columns.Add("Seconds");

            foreach (var sessionData in list)
            {
                times.Add((TimeSpan) sessionData[6]);
                count++;
            }

            var totalTimeSpan = new TimeSpan(times.Sum(r => r.Duration().Ticks));
            table.Rows.Add(count, totalTimeSpan.Hours, totalTimeSpan.Minutes, totalTimeSpan.Seconds);

            GenerateConsoleTable("Session Totals", table);
        }

        private static void GenerateConsoleTable(string title, DataTable table)
        {
            ConsoleTableBuilder
                .From(table)
                .WithTitle(title)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition, FramePipCharacters)
                .ExportAndWriteLine();
        }
    }
}