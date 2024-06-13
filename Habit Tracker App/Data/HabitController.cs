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
            Console.WriteLine("Habit added successfully.");
        }

        public void GetHabits()
        {
            var habits = _habitService.GetHabits();
            View.GetHabitsView.DisplayHabits(habits);
        }

        public void DeleteHabit(int habitId)
        {
            _habitService.DeleteHabitRecord(habitId);
            Console.WriteLine("Habit deleted successfully.");
        }

        public void UpdateHabit(Habit habit)
        {
            _habitService.UpdateHabit(habit);
            Console.WriteLine("Habit updated successfully.");
        }
    }
}
