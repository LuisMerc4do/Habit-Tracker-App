using System.Data.SQLite;

namespace Habit_Tracker_App.Data
{
    public class HabitContext
    {
        private const string ConnectionString = "Data Source=habit_tracker.db";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
