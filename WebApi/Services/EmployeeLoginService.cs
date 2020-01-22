using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmployeeLoginService
    {
        public static bool isLoginValid(string username, string password)
        {
            try
            {
                using (EmployeeEntities dbContext = new EmployeeEntities())
                {
                    return dbContext.EmployeeCredentials.Any(user => user.UserName == username && user.Password == password);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}