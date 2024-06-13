using System.Data.SQLite;

namespace Habit_Tracker_App.Data
{
    public static class DatabaseInitializer
    {
        private const string DbName = "habit_tracker.db";

        public static void InitDatabase()
        {
            SQLiteConnection.CreateFile(DbName); // Create the SQLite database file if not exists
            Console.WriteLine("Creating a new Database habit_tracker.db...");
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                // Create table SQL command
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL, 
                    Date TEXT,
                    Quantity TEXT
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery(); // Execute SQL command to create table
                }
            }
        }
        private static string GetConnectionString()
        {
            return $"Data Source={DbName};Version=3;";
        }
    }
}
