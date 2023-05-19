using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Entities.Models;

namespace UserRegistrationAPI.Service.IService
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool isTrackChanges);
        User GetById(int id, bool isTrackChanges);
        User GetByEmail(string email, bool isTrackChanges);
        User GetByEmailAndPassword(string email, string password, bool isTrackChanges);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
