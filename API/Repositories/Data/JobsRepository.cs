using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class JobsRepository : IJobsRepository
    {
        MyContext myContext;

        public JobsRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var dataDelete = Get(id);
            myContext.Jobs.Remove(dataDelete);
            var resultDelete = myContext.SaveChanges();
            return resultDelete;
        }

        public List<Jobs> Get()
        {
            var dataGet = myContext.Jobs.ToList();
            return dataGet;
        }

        public Jobs Get(int id)
        {
            var dataGet = myContext.Jobs.Find(id);
            return dataGet;
        }

        public int Post(Jobs jobs)
        {
            myContext.Jobs.Add(jobs);
            var resultPost = myContext.SaveChanges();
            return resultPost;
        }

        public int Put(Jobs jobs)
        {
            var dataPut = Get(jobs.JobId);
            dataPut.JobName = jobs.JobName;
            myContext.Jobs.Update(dataPut);
            var resultPut = myContext.SaveChanges();
            return resultPut;
        }
    }
}
