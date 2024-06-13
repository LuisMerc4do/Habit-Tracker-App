namespace Habit_Tracker_App.Data
{
    public class HabitService
    {
        private readonly HabitRepository _repository;

        public HabitService()
        {
            _repository = new HabitRepository();
        }

        public void AddHabit(Habit habit)
        {
            _repository.AddHabit(habit);
        }

        public void DeleteHabitRecord(Habit habit)
        {
            _repository.DeleteHabitRecord(habit);
        }
        public void DeleteHabitCategory(Habit habit)
        {
            _repository.DeleteHabitCategory(habit);
        }
        public void UpdateHabit(Habit habit)
        {
            _repository.UpdateHabit(habit);
        }
        public List<Habit> GetHabits()
        {
            return _repository.GetHabits();
        }
    }
}
