namespace MyTaskApi.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}