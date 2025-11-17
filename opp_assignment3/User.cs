


using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace opp_assignment3
{
    public class User
    {
        private int id;

        public int Id
        {
            get

            {
               
                return id;
            }
           

           
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length >=3)
                {
                    name=value;
                }
                else
                {
                    Console.WriteLine("invalid name,try again ");
                    value = name;


                }

            }
        }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.Contains("@") && value.Contains("."))
                {
                    email=value;
                }
                else
                {
                    Console.WriteLine("invalid email ");
                    value = email;

                }

            }
                }

       public  List<TaskApp> taskApp { get; set; }
        public User()
        {
            taskApp = new List<TaskApp>();
           

        }

        static List<User> userlist = new List<User>();
        public void AddUser(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.Name) && user.Name.Length >= 3
               && !string.IsNullOrWhiteSpace(user.Email))
            {
                userlist.Add(user);
                Console.WriteLine("User added successfully! ");
            }
            else
            {
                Console.WriteLine("user not added ,check again please ");
            }
           
            

        }
  //-------------------
        public string AddUserTask(TaskApp task)
        {
          
             taskApp.Add(task);
            return "Task added successfully!";

            
        }
 //-------------------
        public string RemoveUserTask(int taskId)
        {
            for(int i = 0;i<taskApp.Count;i++)
            {
                if (taskApp[i].Id == taskId)
                {
                    taskApp.RemoveAt(i);
                    return "Task removed successfully.";
                }
            }

            return "Task not found";
        }
 //-------------------
        public List<TaskApp> GetActiveUserTasks()
        {
            var progress = new List<TaskApp>();

        foreach (var item in taskApp)
        {
        
        if  (item.TaskStatus == Status.InProgress)
        {
                  progress.Add(item);

        }
          else if (item.TaskStatus == Status.Pending)
        {
                    progress.Add(item);
        }

          }
            return progress;
      }
  

    }




    }

