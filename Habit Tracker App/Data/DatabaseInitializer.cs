using System;
using System.Data.SQLite;

namespace Habit_Tracker_App.Data
{
    public static class DatabaseInitializer
    {
        private const string DbName = "habit_tracker.db";

        public static void InitDatabase()
        {
            SQLiteConnection.CreateFile(DbName); // Create SQLite database file if not exists
            Console.WriteLine("Creating a new database habit_tracker.db...");
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                // Create table SQL command
                tableCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Date TEXT,
                    Quantity INTEGER
                )";
                tableCmd.ExecuteNonQuery();
                Console.WriteLine("Database created successfully.");
            }
        }

        private static string GetConnectionString()
        {
            return $"Data Source={DbName}";
        }
    }
}
