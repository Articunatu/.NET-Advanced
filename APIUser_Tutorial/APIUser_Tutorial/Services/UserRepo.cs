using APIUser_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser_Tutorial.Services
{
    public class UserRepo : IUserRepository
    {
        private List<User> users = new List<User>()
        {
            new User{Name = "Ostman", ID = 1},
            new User{Name = "Tomaten", ID = 2},
            new User{Name = "Gurkmajo", ID = 3}
        };
        public void CreateUser(User newUser)
        {
            users.Add(newUser);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public List<User> ReadAllUsers()
        {
            return users;
        }

        public User ReadUser(int id)
        {
            return users.FirstOrDefault(u => u.ID == id);
        }

        public User UpdateUser(User user)
        {
            var exUser = ReadUser(user.ID);
            exUser.Name = user.Name;
            return user;
        }
    }
}
