namespace MyTaskApi.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}