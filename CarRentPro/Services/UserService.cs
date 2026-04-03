using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Enums;
using CarRentPro.Models;
using CarRentPro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Services
{
    public class UserService
    {
        private UserRepository userRepository=new UserRepository();


        public object LoginUser(string email, string password)
        {
            var user = userRepository.ValidateUser(email, password);

            if (user == null)
                throw new Exception("Invalid Email or Password");

            return new
            {
                user.Id,
                user.Name,
                user.Email,
                Role = user.Role.ToString()
            };
        }
        public object GetUsers()
        {
            return userRepository.GetUsers();
        }
        public UserResponseDto GetUserByID(long id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null || user.Deleted)
            {
                return null;
            }
            return new UserResponseDto
            {
                Id=user.Id,
                Name=user.Name,
                Email = user.Email,
                Address = user.Address,
                Role = (int)user.Role
            };
        }

        public UserResponseDto CreateUser(CreateUserDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Address=dto.Address,
                Role = (UserRole)dto.Role
            };
           user= userRepository.CreateUser(user);
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email=user.Email,
                Address = user.Address,
                Role = (int)user.Role
            };
        }

        public UserResponseDto UpdateUser(long id,CreateUserDTO dto)
        {
            var user = userRepository.GetUserById(id);
            if (user == null || user.Deleted)
            {
                return null;
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Address = dto.Address;
            user.Role = (UserRole)dto.Role;

            userRepository.Save();
         
            return new UserResponseDto
            {
                Id=user.Id,
                Name = user.Name,
                Email=user.Email,
                Address = user.Address,
                Role = (int)user.Role
            };
        }

        public bool DeleteUser(long id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null || user.Deleted)
            {
                return false;
            }
            user.Deleted = true;
            userRepository.Save();
            return true;
        }

        
    }
}