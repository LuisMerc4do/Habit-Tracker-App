using System.Data.SQLite;

namespace Habit_Tracker_App.Data
{
    public class HabitRepository
    {
        private readonly HabitContext _context;

        public HabitRepository()
        {
            _context = new HabitContext();
        }
        public void AddHabit(Habit habit)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO habits (Name, Date, Quantity) VALUES (@Name, @Date, @Quantity)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", habit.Name);
                    command.Parameters.AddWithValue("@Date", habit.Date);
                    command.Parameters.AddWithValue("@Quantity", habit.Quantity);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteHabitRecord(Habit habit)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM habits WHERE (Name, Date) VALUES (@Name, @Date)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", habit.Name);
                    command.Parameters.AddWithValue("@Date", habit.Date);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteHabitCategory(Habit habit)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                // Delete all the values from that habit
                var query = "DELETE FROM habits WHERE (Name) VALUES (@Name)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", habit.Name);
                    command.Parameters.AddWithValue("@Date", habit.Date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateHabit(Habit habit)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                // Delete all the values from that habit
                var query = "UPDATE habits SET Name = @Name, Date = @Date, Quantity = @Quantity WHERE @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", habit.Name);
                    command.Parameters.AddWithValue("@Date", habit.Date);
                    command.Parameters.AddWithValue("@Quantity", habit.Quantity);
                    command.Parameters.AddWithValue("@Id", habit.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Habit> GetHabits()
        {
            var habits = new List<Habit>();

            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM habits";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            habits.Add(new Habit
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            });
                        }
                    }
                }
            }

            return habits;
        }
    }
}

