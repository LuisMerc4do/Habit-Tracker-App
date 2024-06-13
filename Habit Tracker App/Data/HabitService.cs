using System.Collections.Generic;

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

        public void DeleteHabitRecord(int habitId)
        {
            _repository.DeleteHabitRecord(habitId);
        }

        public bool HabitExists(int id)
        {
            return _repository.HabitExists(id);
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
