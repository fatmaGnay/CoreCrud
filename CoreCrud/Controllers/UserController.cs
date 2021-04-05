using Data.Context;
using Data.Dto;
using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        MasterContext masterContext = new MasterContext();
        public UserController()
        {

        }
        [HttpPost("AddUser")]
        public string AddUser(SaveUserDto saveUserDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                User user = new User()
                {
                    Id = saveUserDto.Id,
                    UserName = saveUserDto.UserName,
                    Password = saveUserDto.Password
                };
                unitOfWork.GetRepository<User>().Add(user);
                unitOfWork.SaveChange();
                return "Kullanıcı kayıdı başarılı";

            }
        }

        [HttpGet("GetUser")]
        public User GetUser(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                return unitOfWork.GetRepository<User>().Get(id);
            }
        }
        [HttpPut("SetUser")]
        public string SetUser(SaveUserDto saveUserDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                User user = unitOfWork.GetRepository<User>().Get(saveUserDto.Id);// Veriyi çektik user adlı nesneye attık 
                user.UserName = saveUserDto.UserName;
                user.Password = saveUserDto.Password;
                unitOfWork.GetRepository<User>().Update(user);
                unitOfWork.SaveChange();
            }
            return "Kullanıcı güncellemesi başarılı";
        }
        [HttpDelete ("DeleteUser")]
        public string DeleteUser(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                User user = unitOfWork.GetRepository<User>().Get(id);
                unitOfWork.GetRepository<User>().Delete(user);
                unitOfWork.SaveChange();
            }
            return "Kullanıcı silme işlemi başarılı";
        }
    }
}
