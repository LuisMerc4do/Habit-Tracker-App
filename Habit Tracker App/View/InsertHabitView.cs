namespace Habit_Tracker_App.View
{
    public static class InsertHabitView
    {
        public static Habit InsertHabitDetails()
        {
            Console.WriteLine("Enter new habit name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter the times you have done {name} Today:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            return new Habit
            {
                Name = name,
                Date = DateTime.Now,
                Quantity = quantity
            };
        }
    }
}
