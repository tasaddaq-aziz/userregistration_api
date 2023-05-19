using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Entities.Models;

namespace UserRegistrationAPI.Application.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool isTrackChanges);
        User GetById(int id, bool isTrackChanges);
        User GetByEmail(string email, bool isTrackChanges);
        User GetByEmailAndPassword(string email, string password, bool isTrackChanges);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
