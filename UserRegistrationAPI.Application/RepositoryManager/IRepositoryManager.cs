using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationAPI.Application.Repository;

namespace UserRegistrationAPI.Application.RepositoryManager
{
    public interface IRepositoryManager
    {
        
        void Save();

        /// <summary>
        /// These are Property inside Interface (Not a method). 
        /// I just define GET method for them
        /// </summary>
        UserRepository User { get; }
    }
}
