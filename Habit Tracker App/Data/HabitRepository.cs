﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;

namespace Habit_Tracker_App.Data
{
    public class HabitRepository
    {
        private static string GetConnectionString()
        {
            return $"Data Source=habit_tracker.db";
        }

        public void AddHabit(Habit habit)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    var query = "INSERT INTO habits (Name, Date, Quantity) VALUES (@Name, @Date, @Quantity)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", habit.Name);
                        command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Quantity", habit.Quantity);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Habit added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows inserted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding habit: {ex.Message}");
                }
            }
        }

        public bool HabitExists(int id)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                var query = "SELECT COUNT(1) FROM habits WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void DeleteHabitRecord(int habitId)
        {
            try
            {
                if (!HabitExists(habitId))
                {
                    Console.WriteLine($"Habit with Id {habitId} does not exist.");
                    return;
                }
                using (var connection = new SQLiteConnection(GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "DELETE FROM habits WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", habitId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Habit Removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting habits: {ex.Message}");
            }
        }

        public void UpdateHabit(Habit habit)
        {
            if (!HabitExists(habit.Id))
            {
                Console.WriteLine($"Habit with Id {habit.Id} does not exist.");
                return;
            }

            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    var query = "UPDATE habits SET Name = @Name, Date = @Date, Quantity = @Quantity WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", habit.Name);
                        command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Quantity", habit.Quantity);
                        command.Parameters.AddWithValue("@Id", habit.Id);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Habit updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows updated.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating habit: {ex.Message}");
                }
            }
        }

        public List<Habit> GetHabits()
        {
            List<Habit> habits = new List<Habit>();

            try
            {
                using (var connection = new SQLiteConnection(GetConnectionString()))
                {
                    connection.Open();

                    var query = "SELECT Id, Name, Date, Quantity FROM habits";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                DateTime date = DateTime.Parse(reader.GetString(2)); // Adjust date parsing as per your database format
                                int quantity = reader.GetInt32(3);

                                habits.Add(new Habit
                                {
                                    Id = id,
                                    Name = name,
                                    Date = date,
                                    Quantity = quantity
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving habits: {ex.Message}");
            }

            return habits;
        }
    }
}

