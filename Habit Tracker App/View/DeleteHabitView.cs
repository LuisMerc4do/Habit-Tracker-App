namespace Habit_Tracker_App.View
{
    public static class DeleteHabitView
    {
        public static int DeleteHabitRecord()
        {
            Console.WriteLine("Enter the Habit ID you want to delete:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Input. Please enter a number.");
            }
            return id;
        }
    }
}
