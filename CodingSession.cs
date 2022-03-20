using System;

namespace CodingTracker
{
    public class CodingSession
    {
        public int Id;
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

            var conn = DbUtils.GenerateConnection();
            var cmd = conn.CreateCommand();
            var format = "yyyy-MM-dd HH:mm:ss";

            try
            {
                cmd.CommandText =
                    "INSERT INTO Coding_Session (Start_Time, End_Time, Duration) VALUES" +
                    $" ('{_startTime.ToString(format)}', '{_endTime.ToString(format)}', {_duration.TotalSeconds})";
                cmd.ExecuteNonQuery();

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Coding_Session ORDER BY ID DESC LIMIT 1";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Id = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Something went wrong: " + e);
            }


            conn.Close();
        }

        public TimeSpan GetDuration() => _duration;
    }
}