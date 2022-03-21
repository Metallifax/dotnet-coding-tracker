using System;
using static CodingTracker.utils.DbUtils;

namespace CodingTracker.model
{
    public class CodingSession
    {
        private int _id;
        private DateTime _startTime;
        private DateTime _endTime;
        private TimeSpan _duration;

        public void StartSession()
        {
            _startTime = DateTime.Now;
        }

        public void StopSession()
        {
            _endTime = DateTime.Now;
            _duration = _endTime.Subtract(_startTime);

            try
            {
                using var conn = GenerateConnection();
                using var cmd = conn.CreateCommand();
                const string format = "yyyy-MM-dd HH:mm:ss";
                
                cmd.CommandText =
                    "INSERT INTO Coding_Session (Start_Time, End_Time, Duration) VALUES" +
                    $" ('{_startTime.ToString(format)}', '{_endTime.ToString(format)}', {_duration.TotalSeconds})";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT * FROM Coding_Session ORDER BY ID DESC LIMIT 1";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _id = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Something went wrong: " + e);
            }
        }

        public TimeSpan GetDuration() => _duration;
    }
}