using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Services.UserManagement
{
    public interface IUserManagementService
    {
        bool IsValidUser(string username, string password);
    }
}
