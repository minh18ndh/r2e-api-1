using MyTaskApi.Models;

namespace MyTaskApi.Interfaces
{
    public interface ITaskRepository
    {
        TaskItem AddTask(TaskItem task);
        IEnumerable<TaskItem> GetAllTask();
        TaskItem? GetTask(Guid id);
        bool DeleteTask(Guid id);
        bool UpdateTask(TaskItem updatedTask);
        void BulkAddTask(IEnumerable<TaskItem> tasks);
        void BulkDeleteTask(IEnumerable<Guid> ids);
    }
}