using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Application.RepositoryManager;
using UserRegistrationAPI.Entities.Models;
using UserRegistrationAPI.Service.IService;

namespace UserRegistrationAPI.Service.Service
{
    public class UserService : IUserService
    {
        private IRepositoryManager _repository;
        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public void CreateUser(User user)
        {
            _repository.User.CreateCompany(user);
            _repository.Save();
        }

        public void DeleteUser(User company)
        {
            _repository.User.DeleteCompany(company);
            _repository.Save();
        }

        public IEnumerable<User> GetAllUsers(bool isTrackChanges)
        {
            return _repository.User.GetAllUsers(isTrackChanges);
        }

        public User GetByEmail(string email, bool isTrackChanges)
        {
            return _repository.User.GetByEmail(email, isTrackChanges);
        }

        public User GetByEmailAndPassword(string email, string password, bool isTrackChanges)
        {
            return _repository.User.GetByEmailAndPassword(email,password, isTrackChanges);
        }

        public User GetById(int id, bool isTrackChanges)
        {
            return _repository.User.GetById(id, isTrackChanges);
        }

        public void UpdateUser(User user)
        {
            _repository.User.Update(user);
            _repository.Save();
        }
    }
}
