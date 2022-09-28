using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IJobsRepository
    {
        List<Jobs> Get();

        Jobs Get(int id);

        int Post(Jobs jobs);

        int Put(Jobs jobs);
        
        int Delete(int id);
    }
}
