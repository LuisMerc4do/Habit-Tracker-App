using System;

namespace Habit_Tracker_App.Data
{
    public class HabitController
    {
        private readonly HabitService _habitService;

        public HabitController()
        {
            _habitService = new HabitService();
        }

        public void InsertHabit()
        {
            var habit = View.InsertHabitView.InsertHabitDetails();
            _habitService.AddHabit(habit);
        }

        public void GetHabits()
        {
            var habits = _habitService.GetHabits();
            View.GetHabitsView.DisplayHabits(habits);
        }

        public void DeleteHabit()
        {
            _habitService.DeleteHabitRecord(View.DeleteHabitView.DeleteHabitRecord()); 
        }

        public void UpdateHabit()
        {
            Console.WriteLine("Enter the ID of the habit you want to update:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existingHabit = _habitService.GetHabits().FirstOrDefault(h => h.Id == id);
                if (existingHabit == null)
                {
                    Console.WriteLine($"Habit with ID {id} not found.");
                    return;
                }

                var updatedHabit = View.UpdateHabitView.UpdateHabitDetails(existingHabit);
                _habitService.UpdateHabit(updatedHabit);
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
            }
        }
    }
}
