using Microsoft.AspNetCore.Mvc;
using MyTaskApi.DTOs;
using MyTaskApi.Interfaces;

namespace MyTaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public ActionResult<TaskDto> CreateTask(CreateTaskDto dto)
        {
            var result = _taskService.CreateTask(dto);
            return CreatedAtAction(nameof(GetTaskById), new { id = result.Id }, result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAllTask() => Ok(_taskService.GetAllTask());

        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetTaskById(Guid id)
        {
            var task = _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            bool deleted = _taskService.DeleteTask(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, UpdateTaskDto dto)
        {
            bool updated = _taskService.UpdateTask(id, dto);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("bulk")]
        public IActionResult BulkAddTask(IEnumerable<CreateTaskDto> tasks)
        {
            _taskService.BulkAddTask(tasks);
            return Ok();
        }

        [HttpDelete("bulk")]
        public IActionResult BulkDeleteTask([FromBody] IEnumerable<Guid> ids)
        {
            _taskService.BulkDeleteTask(ids);
            return NoContent();
        }
    }
}