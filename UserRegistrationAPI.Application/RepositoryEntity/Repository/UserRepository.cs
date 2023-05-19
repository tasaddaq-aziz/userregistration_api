using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Application.IRepository;
using UserRegistrationAPI.Application.RepositoryBase;
using UserRegistrationAPI.Entities.Context;
using UserRegistrationAPI.Entities.Models;

namespace UserRegistrationAPI.Application.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }

        public void CreateCompany(User user)
        {
            Create(user);
        }

        public void DeleteCompany(User user)
        {
            Delete(user);
        }

        public IEnumerable<User> GetAllUsers(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public User GetById(int id, bool isTrackChanges)
        {
            return FindByCondition(c => c.USER_ID == id, isTrackChanges).FirstOrDefault();
        }

        public User GetByEmail(string email, bool isTrackChanges)
        {
            return FindByCondition(c => c.EMAL == email, isTrackChanges).FirstOrDefault();
        }
        public User GetByEmailAndPassword(string email, string password, bool isTrackChanges)
        {
            return FindByCondition(c => c.EMAL == email && c.PWRD == password, isTrackChanges).FirstOrDefault();
        }

        public void UpdateCompany(User user)
        {
            Update(user);
        }
    }
}
