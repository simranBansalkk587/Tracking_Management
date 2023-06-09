using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Models;

namespace Tracking_Task.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string Name);
        User Authenticate(string Name, string password);
        User Register(string Name, string Address,string Age,string Email,String Password,string role);
    }
}
