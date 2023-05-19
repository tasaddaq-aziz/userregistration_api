using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Application.Repository;
using UserRegistrationAPI.Entities.Context;

namespace UserRegistrationAPI.Application.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private UserDbContext _context;
        public RepositoryManager(UserDbContext context)
        {
            _context = context;
        }

        private UserRepository _userRepository;
        public UserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
