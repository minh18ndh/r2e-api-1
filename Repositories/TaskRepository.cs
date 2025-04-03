using MyTaskApi.Interfaces;
using MyTaskApi.Models;
using MyTaskApi.DTOs;

namespace MyTaskApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly List<TaskItem> _tasks = new();

        public TaskItem AddTask(TaskItem task)
        {
            _tasks.Add(task);
            return task;
        }

        public IEnumerable<TaskItem> GetAllTask() => _tasks;

        public TaskItem? GetTask(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
        
        public bool DeleteTask(Guid id)
        {
            var task = GetTask(id);
            if (task == null)
            {
                return false;
            }
            _tasks.Remove(task);
            return true;
        }

        public bool UpdateTask(TaskItem updatedTask)
        {
            var existingTask = GetTask(updatedTask.Id);
            if (existingTask == null)
            {
                return false;
            }
            existingTask.Title = updatedTask.Title;
            existingTask.IsCompleted = updatedTask.IsCompleted;
            return true;
        }

        public void BulkAddTask(IEnumerable<TaskItem> tasks)
        {
            _tasks.AddRange(tasks);
        }

        public void BulkDeleteTask(IEnumerable<Guid> ids)
        {
            _tasks.RemoveAll(t => ids.Contains(t.Id));
        }
    }
}