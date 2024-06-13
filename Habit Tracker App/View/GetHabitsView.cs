using System;
using System.Collections.Generic;
using Habit_Tracker_App.Data;

namespace Habit_Tracker_App.View
{
    public static class GetHabitsView
    {
        public static void DisplayHabits(List<Habit> habits)
        {
            Console.WriteLine("Habits:");
            Console.WriteLine("ID   Name          Date          Quantity");
            foreach (var habit in habits)
            {
                Console.WriteLine($"{habit.Id} - {habit.Name,-15} {habit.Date.ToString("dd-MMM-yyyy"),-12} {habit.Quantity}");
            }
        }
    }
}
