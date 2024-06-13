using Habit_Tracker_App.Data;

namespace Habit_Tracker_App.View
{
    public static class GetHabitsView
    {
        public static void GetHabitsDetails(List<Habit> habits)
        {
                Console.WriteLine("Habits:");
                Console.WriteLine("ID   Name          Quantity");

                foreach (var habit in habits)
                {
                    Console.WriteLine($"{habit.Id,-4} {habit.Name,-14} {habit.Quantity}");
                }
        }
    }
}
