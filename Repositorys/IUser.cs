using Restful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public interface IUser
    {

        Task<UserLogin> CreateUser(string username, string password, string fullname, string email);

        string Authenticate(string username, string password);
    }
}
