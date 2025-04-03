namespace MyTaskApi.DTOs
{
    public class CreateTaskDto
    {
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}