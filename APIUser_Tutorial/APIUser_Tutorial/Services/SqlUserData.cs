using APIUser_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser_Tutorial.Services
{
    public class SqlUserData : IUserRepository
    {
        private UserDbContext _userContext;

        public SqlUserData(UserDbContext userContext)
        {
            _userContext = userContext;
        }

        public void CreateUser(User newUser)
        {
            _userContext.Users.Add(newUser);
            _userContext.SaveChanges();
        }

        public void DeleteUser(User newUser)
        {
            _userContext.Users.Remove(newUser);
            _userContext.SaveChanges();
        }

        public List<User> ReadAllUsers()
        {
            return _userContext.Users.ToList();
        }

        public User ReadUser(int id)
        {
            return _userContext.Users.FirstOrDefault( u => u.ID.Equals(id));
        }

        public User UpdateUser(User newUser)
        {
            var existUser = _userContext.Users.Find(newUser.ID);
            if (existUser != null)
            {
                existUser.Name = newUser.Name;
                _userContext.Users.Update(existUser);
                _userContext.SaveChanges();
            }
            return newUser;
        }
    }
}
