using System.Data.SQLite;
using System.IO;

namespace CodingTracker.utils
{
    public static class DbUtils
    {
        private const string DbPath = "database.db";

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
    }
}