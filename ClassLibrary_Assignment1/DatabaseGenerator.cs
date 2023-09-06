using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary_Assignment1
{
    public class DatabaseGenerator
    {
        private String name;
        private String username;
        private String password;

        /*public void GetData(out string name,out String username,out String password)
        {
            
        }*/

        public void GetData(out string dbName, out string dbUsername, out string dbPassword)
        {
            // Assign values to the out parameters
            dbName = "YourDatabaseName";
            dbUsername = "YourUsername";
            dbPassword = "YourPassword";
        }

    }

}
