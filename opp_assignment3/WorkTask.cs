using opp_assignment3;

public class WorkTask : TaskApp
{
    public string Company { get; set; }

    public WorkTask(string title, string description, DateTime? dueDate, string company)
        : base(title, description, dueDate)  
    {
        this.Company = company;
    }
}