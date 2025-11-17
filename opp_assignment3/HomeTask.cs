using opp_assignment3;

public class HomeTask : TaskApp
{
    public string Room { get; set; }

    public HomeTask(string title, string description, DateTime? dueDate, string room)
        : base(title, description, dueDate)
    {
        this.Room = room;
    }
}