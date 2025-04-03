using MyTaskApi.DTOs;
using MyTaskApi.Interfaces;
using MyTaskApi.Models;

namespace MyTaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskDto CreateTask(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            };
            _taskRepository.AddTask(task);
            return MapToDto(task);
        }

        public IEnumerable<TaskDto> GetAllTask() => _taskRepository.GetAllTask().Select(MapToDto);

        public TaskDto? GetTask(Guid id)
        {
            var task = _taskRepository.GetTask(id);
            if (task == null)
            {
                return null;
            }
            return MapToDto(task);
        }

        public bool DeleteTask(Guid id) => _taskRepository.DeleteTask(id);

        public bool UpdateTask(Guid id, UpdateTaskDto dto)
        {
            var task = _taskRepository.GetTask(id);
            if (task == null) 
            {
                return false;
            }
            task.Title = dto.Title;
            task.IsCompleted = dto.IsCompleted;
            return _taskRepository.UpdateTask(task);
        }

        public void BulkAddTask(IEnumerable<CreateTaskDto> tasks)
        {
            var taskItems = tasks.Select(dto => new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            });
            _taskRepository.BulkAddTask(taskItems);
        }

        public void BulkDeleteTask(IEnumerable<Guid> ids) => _taskRepository.BulkDeleteTask(ids);

        private static TaskDto MapToDto(TaskItem task) => new()
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted  
        };
    }
}