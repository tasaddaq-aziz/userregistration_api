using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Entities.Models;

namespace UserRegistrationAPI.Tests.MockData
{
    public class UserMockData
    {
        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User() { USER_ID = 1, FRST_NAME =  "Tasaddaq",LAST_NAME="Aziz",EMAL="tasaddaq@gmail.com"},
               new User() { USER_ID = 2, FRST_NAME =  "Ali",LAST_NAME="Raza",EMAL="tasaddaq@gmail.com"},
            };
        }
    }
}
