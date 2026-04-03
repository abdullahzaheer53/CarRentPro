using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace CarRentPro.Repository
{
    public class UserRepository
    {
        public AppDbContext db= new AppDbContext();

        public User ValidateUser(string email, string password)
        {
            return db.Users
                .FirstOrDefault(x => x.Email == email
                                  && x.Password == password
                                  && x.Deleted == false);
        }
        public List<UserResponseDto> GetUsers()
        {
            return db.Users
              .Where(x => x.Deleted == false)
              .Select(x => new UserResponseDto
              {
                  Id=x.Id,
                  Name=x.Name,
                  Email = x.Email,
                  Address = x.Address,
                  Role = (int)x.Role
              }).ToList();
        }

        public User GetUserById(long id)
        {
            return db.Users.Find(id);
            
        }
        public User CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        


    }
}