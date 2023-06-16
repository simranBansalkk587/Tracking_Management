using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Models;

namespace Tracking_Task.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        IEnumerable<User> GetAllUser();
        bool IsUniqueUser(string Email);
        User Authenticate(string Email, string password);
        User Register(string Name, string Address,string Age,string Email,String Password,string role);
    }
}
