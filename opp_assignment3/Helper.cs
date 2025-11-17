

namespace opp_assignment3
{
    public static class Helper
    {

        public static string DateFormat(DateTime date)
        {

            return date.ToString("dd-MM-yyyy");
        }

        public static int Idcounter=0;
        public static int GenerateId(int id)
        {

        return Idcounter++; 
        }

        static List<User> userlist = new List<User>();


    }
}
