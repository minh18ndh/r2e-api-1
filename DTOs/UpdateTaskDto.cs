namespace MyTaskApi.DTOs
{
    public class UpdateTaskDto
    {
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}