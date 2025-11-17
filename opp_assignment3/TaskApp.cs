
using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace opp_assignment3
{
    public  class TaskApp 
    {
        private static int counter = 1;

        public int Id { get; protected set; }
        
        private string title { get; set; }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                   title = value;

                }
                else
                {
                    Console.WriteLine("Can not be null");
                }
            }
        }
        public Status TaskStatus { get; set; }
        private string desc;
        public string Description { get; set; }

        private DateTime? duedate;
        public DateTime? DueDate
        {
            get
            {
                   return duedate;
                
            }
            set
            {
                if (value<DateTime.Today)
                {
                    duedate=null;

                }
                else
                {
                     duedate = value;
                }
            }
        }
        public TaskApp(string title, string description, DateTime? dueDate)
        {

            this.Id = counter++;
            this.Title = title;
            this.Description = desc;
            this.DueDate = duedate;
            this.TaskStatus = Status.Pending;
            
        }

        public void  MarkAsDone(TaskStatus task)
        {
         
            if(TaskStatus !=Status.Done)
            {
               
                Console.WriteLine("The Task is Marked as Done ");
            }
            else
            {
                Console.WriteLine("Invalid its already done ");

            }


        }

        public List<TaskApp> tasks = new List<TaskApp>();
        public void AddTask(TaskApp task)
        {
          
                tasks.Add(task);
            
        }

        public List<TaskApp> ListAllTasks()
        {
         
            return tasks;


        }

        public List<string> Searchtask(string input )
        {
            List<string> result = new List<string>();

            for (int i = 0; i <tasks.Count ; i++)
            {
              if (Title.ToLower().Contains(input.ToLower()) )
               {
                  result.Add(Title);
               }
              else if (TaskStatus.ToString().ToLower()==input.ToLower())
              {
                    result.Add(Title);
              }

            }
            if(result.Count==0)
            {
                Console.WriteLine(" No Data Found");
            }
           
               
             return result;
        }


    }
}
