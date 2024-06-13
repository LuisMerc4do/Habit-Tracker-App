using Habit_Tracker_App.Data;

namespace Habit_Tracker_App
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseInitializer.InitDatabase();
            var habitController = new HabitController();
            MenuView.DisplayMainMenu(habitController);
        }
    }
}