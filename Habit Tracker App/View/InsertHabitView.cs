﻿namespace Habit_Tracker_App.View
{
    public static class InsertHabitView
    {
        public static Habit InsertHabitDetails()
        {
            Console.WriteLine("Enter new habit name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the times you have done this habit today:");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity. Please enter a number.");
            }

            return new Habit
            {
                Name = name,
                Quantity = quantity
            };
        }
    }
}
