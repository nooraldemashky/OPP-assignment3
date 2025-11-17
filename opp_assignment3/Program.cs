using Microsoft.VisualBasic;
using opp_assignment3;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Xml.Linq;


TaskApp taskApp = new TaskApp(
    "task",
    "work",
    new DateTime(2025,11,17)
);
User user6= new User();



List<User> users= new List<User>();

Console.WriteLine("===Welcome To Task Manager Menu ===");
Console.WriteLine("1) Register User");
Console.WriteLine("2) Add Task");
Console.WriteLine("3) List All Tasks");
Console.WriteLine("4) Search Tasks");
Console.WriteLine("5) Mark Task as Done");
Console.WriteLine("6) Remove Task");
Console.WriteLine("7) Get the task that isnot completed");
Console.WriteLine("8) Exit");

Console.WriteLine("Be Productive");

Console.Write("Choose option: ");
int input = Convert.ToInt32(Console.ReadLine());

switch (input)
{
    case 1:
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();


            User user = new User();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine(" Invalid Data.");
            }
            else
            {
                user.Name = name;
                user.Email = email;
                users.Add(user);

                
                Console.WriteLine(" User Added successfully!");
            }
        }
        break;

    case 2:
        {

            Console.Write("Add your Task Tilte : Work - Study - Home ");
            string title = Console.ReadLine();

            Console.Write("Enter The Description: ");
            string des = Console.ReadLine();

          

            Console.Write("Enter The Date (yyyy-mm-dd): ");
            string duedate = Console.ReadLine();
            DateTime dueDate = DateTime.Parse(duedate);


           


            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(" Invalid Title");
                break;
            }
            


            if (dueDate < DateTime.Today)
            {
                Console.WriteLine("The date cannot be in the past");

            }
            else
            {

                string formattedDate = Helper.DateFormat(dueDate);
                Console.WriteLine("Due Date: " + formattedDate);


            }
            if (users.Count == 0)
            {
                Console.WriteLine("No users registered yet!");
                break;
            }

            Console.WriteLine("Select a user by number:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {users[i].Name} - {users[i].Email}");
            }
            int selectedIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if (selectedIndex < 0 || selectedIndex >= users.Count)
            {
                Console.WriteLine("Invalid selection!");
                break;
            }
            User selectedUser = users[selectedIndex];

            TaskApp task = null;

            
            if (title.ToLower() == "work")
            {
                Console.Write("Enter Company Name: ");
                string company = Console.ReadLine();
               
                task = new WorkTask(title, des, dueDate, company);
                taskApp.tasks.Add(task);
            }
            else if (title.ToLower() == "study")
            {
                Console.Write("Enter Subject: ");
                string subject = Console.ReadLine();
                task = new StudyTask(title, des, dueDate, subject);
                taskApp.tasks.Add(task);
            }
            else if (title.ToLower() == "home")
            {
                Console.Write("Enter Room Name: ");
                string room = Console.ReadLine();
                task = new HomeTask(title, des, dueDate, room);
                taskApp.tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Invalid Task Type");
                break;
            }
            Console.WriteLine("Task created successfully!");
        }
        break;

    case 3:
        {
            if (taskApp.tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                break;
            }

            for (int i = 0; i < taskApp.tasks.Count; i++)
            {
                var item = taskApp.tasks[i];

                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Title: " + item.Title);
                Console.WriteLine("Task Status: " + item.TaskStatus);
                Console.WriteLine($"Due Date" + (item.DueDate.HasValue ? Helper.DateFormat(item.DueDate.Value) : "No Date "));

            }
            break;
        }

    case 4:
        {
            Console.WriteLine("Please enter the task title or the task stastus so we can return the best search ");
            string searchinput = Console.ReadLine();

            List<string> _search = taskApp.Searchtask(searchinput);
            if(_search.Count ==0)
            {
                Console.WriteLine("No found  ");

            }
            else
            {
                foreach (var item in _search)
                {
                    Console.WriteLine($" {item} ");
                }
            }

                

        }
        break;
    case 5:
        {
           Console.WriteLine("Please enter the ID to set the Status done ");
           int done_id = Convert.ToInt32(Console.ReadLine()) ;
            bool found=false;
            for (int i = 0; i < taskApp.tasks.Count; i++)
            {
              int id_task = taskApp.tasks[i].Id;

                if (id_task == done_id)
                {
                    found = true;

                    Status task = taskApp.tasks[i].TaskStatus;
                    if (task != Status.Done)
                    {
                        taskApp.tasks[i].TaskStatus = Status.Done;
                        Console.WriteLine(" The Task is Done ..Bravoo ");
                        
                       

                    }
                    else
                    {
                        Console.WriteLine(" The Task is already Done  ");
                    }
                    break;

                }
                 
            }
            if(found ==false)
            {
                Console.WriteLine("Incorrect ID ");
            }



        }
        break;
    case 6:
        {
            Console.WriteLine("Please enter the ID to delete the task ");
            int task_id = Convert.ToInt32(Console.ReadLine());
            bool found = false;
            for (int i = 0; i < taskApp.tasks.Count; i++)
            {
                int id_task = taskApp.tasks[i].Id;

                if (id_task == task_id)
                {
                    user6.RemoveUserTask(id_task);
                    Console.WriteLine(" The Task is Removed  ");
                    found = true;
                    break;
                }
               

             }
            if(found==false)
            {
                 Console.WriteLine(" The Incoreect ID  ");
            }
              
            

        }
        break;
    case 7:
        {
           var active = user6.GetActiveUserTasks();
            if( active.Count == 0)
            {
                Console.WriteLine("There is no tasks");
            }
            else

            {
                foreach(var item in active )
                {
                    Console.WriteLine($"ID: {item.Id} - Title: {item.Title} - Status: {item.TaskStatus} - DueDate: {item.DueDate}  ");
                }
            }
           



        }
        break;

    case 8:
        {


            Environment.Exit(0);

        }
        break;

}

