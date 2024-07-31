namespace projectef.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual required Category Category { get; set; }
    }
}

public enum Priority
{
    Low, Mid, High
}