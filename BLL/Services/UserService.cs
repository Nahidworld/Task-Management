//using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.BLL.Dtos;
using TaskManagement.BLL.Interfaces;
using TaskManagement.DAL.Interfaces;
using TaskManagement.DAL.Repositories;

namespace TaskManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception("User not found");

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email
            };
        }
        public void RegisterUser(UserRegisterDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Email is required");
            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password is required");

            // You might hash the password here before saving in a real app

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            _userRepository.Add(user);
        }


        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("User Name is required");

            _userRepository.Add(user);
        }

        //public void UpdateUser(User user)
        //{
        //    if (user == null || user.UserId <= 0)
        //        throw new ArgumentException("Invalid User");

        //    _userRepository.Update(user);
        //}

        public void UpdateUser(int id, UserRegisterDto dto)
        {
            var userToUpdate = _userRepository.GetById(id);
            if (userToUpdate == null)
                throw new Exception("User not found");

            // Update fields
            userToUpdate.Name = dto.Name;
            userToUpdate.Email = dto.Email;
            userToUpdate.Password = dto.Password;

            _userRepository.Update(userToUpdate);
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid User ID");

            _userRepository.Delete(id);
        }

        //public void UpdateUser(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
