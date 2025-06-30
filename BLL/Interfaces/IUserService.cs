using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Dtos;

namespace TaskManagement.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void AddUser(User user);
        void RegisterUser(UserRegisterDto dto);  
        //void UpdateUser(int id, UserDto user);
        void DeleteUser(int id);
        void UpdateUser(int id, UserRegisterDto dto);
    }
}

//namespace BLL.Interfaces
//{
//    public interface IUserService
//    {
//        IEnumerable<User> GetAllUsers();
//        User GetUserById(int id);
//        void AddUser(User user);
//        void UpdateUser(User user);
//        void DeleteUser(int id);
//    }
//}