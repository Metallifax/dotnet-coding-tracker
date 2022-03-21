using System;
using static CodingTracker.utils.DbUtils;
using static CodingTracker.utils.Utils;

namespace CodingTracker.controller
{
    public class CodingSessionsController
    {
        public static void ReadCodingSessions()
        {
            using var conn = GenerateConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Coding_Session";
            try
            {
                var reader = cmd.ExecuteReader();
                Print("\n     Habits     ");
                Print("----------------");
                while (reader.Read())
                {
                    Print($"{reader.GetString(1)} (qty {reader.GetDouble(2)})");
                }
            }
            catch (Exception e)
            {
                Print(ReturnError(e));
            }
        }
    }
}