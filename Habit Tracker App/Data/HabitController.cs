using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var updatedHabit = View.InsertHabitView.InsertHabitDetails();
            _habitService.UpdateHabit(updatedHabit);
            Console.WriteLine("Habit added successfully.");
        }
        public void GetHabits()
        {
            var habits = _habitService.GetHabits();
            View.GetHabitsView.GetHabitsDetails(habits);
        }

        // Other methods: InsertHabit, DeleteHabit, ViewHabits
    }
}
