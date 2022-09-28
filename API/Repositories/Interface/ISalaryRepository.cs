using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface ISalaryRepository
    {
        List<Salary> Get();

        Salary Get(int id);

        int Post(Salary salary);

        int Put(Salary salary);

        int Delete(int id);
    }
}
