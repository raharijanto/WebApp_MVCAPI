using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class SalaryRepository : ISalaryRepository
    {
        MyContext myContext;

        public SalaryRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var dataDelete = Get(id);
            myContext.Salary.Remove(dataDelete);
            var resultDelete = myContext.SaveChanges();
            return resultDelete;
        }

        public List<Salary> Get()
        {
            var dataGet = myContext.Salary.ToList();
            return dataGet;
        }

        public Salary Get(int id)
        {
            var dataGet = myContext.Salary.Find(id);
            return dataGet;
        }

        public int Post(Salary salary)
        {
            myContext.Salary.Add(salary);
            var resultPost = myContext.SaveChanges();
            return resultPost;
        }

        public int Put(Salary salary)
        {
            var dataPut = Get(salary.SalaryId);
            dataPut.SalaryAmount = salary.SalaryAmount;
            myContext.Salary.Update(dataPut);
            var resultPut = myContext.SaveChanges();
            return resultPut;
        }
    }
}
