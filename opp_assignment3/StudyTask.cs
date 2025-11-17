using opp_assignment3;

public class StudyTask : TaskApp
{
    public string Subject { get; set; }

    public StudyTask(string title, string description, DateTime? dueDate, string subject)
        : base(title, description, dueDate)
    {
        this.Subject = subject;
    }
}