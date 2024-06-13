using System;

namespace Habit_Tracker_App.View
{
    public static class UpdateHabitView
    {
        public static Habit UpdateHabitDetails(Habit existingHabit)
        {
            Console.WriteLine($"Updating habit with ID: {existingHabit.Id}");

            Console.WriteLine($"Current Name: {existingHabit.Name}");
            Console.WriteLine("Enter new habit name (or press Enter to keep current name):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                existingHabit.Name = newName;
            }

            Console.WriteLine($"Current Quantity: {existingHabit.Quantity}");
            Console.WriteLine($"Enter new quantity for {existingHabit.Name} (or press Enter to keep current quantity):");
            string newQuantityInput = Console.ReadLine();
            if (int.TryParse(newQuantityInput, out int newQuantity))
            {
                existingHabit.Quantity = newQuantity;
            }

            return existingHabit;
        }
    }
}
