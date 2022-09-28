using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IEmployeesRepository
    {
        List<Employees> Get();

        Employees Get(int id);

        int Post(Employees employees);

        int Put(Employees employees);

        int Delete(int id);
    }
}
