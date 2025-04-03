using MyTaskApi.DTOs;

namespace MyTaskApi.Interfaces
{
    public interface ITaskService
    {
        TaskDto CreateTask(CreateTaskDto dto);
        IEnumerable<TaskDto> GetAllTask();
        TaskDto? GetTask(Guid id);
        bool DeleteTask(Guid id);
        bool UpdateTask(Guid id, UpdateTaskDto dto);
        void BulkAddTask(IEnumerable<CreateTaskDto> tasks);
        void BulkDeleteTask(IEnumerable<Guid> ids);
    }
}