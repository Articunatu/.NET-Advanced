using System;
using System.Collections.Generic;
using System.Linq;
using APIUser_Tutorial.Models;
using System.Threading.Tasks;

namespace APIUser_Tutorial.Services
{
    public interface IUserRepository
    {
        List<User> ReadAllUsers();
        public void CreateUser(User newUser);

        public User ReadUser(int id);

        public User UpdateUser(User newUser);

        public void DeleteUser(User newUser);


    }
}
