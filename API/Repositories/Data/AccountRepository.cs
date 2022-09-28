using API.Context;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login(Login login)
        {
            var dataLogin = myContext.UserRole
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employees)
                .FirstOrDefault(x =>
                    x.User.Employees.EmployeeEmail.Equals(login.Email) && 
                    x.User.UserPassword.Equals(login.Password));

            if (dataLogin != null)
            {
                ResponseLogin responseLogin = new ResponseLogin()
                {
                    Id = dataLogin.User.UserId,
                    FullName = dataLogin.User.Employees.EmployeeName,
                    Email = dataLogin.User.Employees.EmployeeEmail,
                    Role = dataLogin.Role.RoleName
                };
                return responseLogin;
            }

            return null;
        }
    }
}
