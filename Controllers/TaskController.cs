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
        public ActionResult<TaskDto> Create(CreateTaskDto dto)
        {
            var result = _taskService.CreateTask(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAll() => Ok(_taskService.GetAllTask());

        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById(Guid id)
        {
            var task = _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            bool deleted = _taskService.DeleteTask(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateTaskDto dto)
        {
            bool updated = _taskService.UpdateTask(id, dto);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("bulk")]
        public IActionResult BulkAdd(IEnumerable<CreateTaskDto> tasks)
        {
            _taskService.BulkAddTask(tasks);
            return Ok();
        }

        [HttpDelete("bulk")]
        public IActionResult BulkDelete([FromBody] IEnumerable<Guid> ids)
        {
            _taskService.BulkDeleteTask(ids);
            return NoContent();
        }
    }
}