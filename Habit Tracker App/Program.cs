using Habit_Tracker_App.Data;
using Habit_Tracker_App.View;

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