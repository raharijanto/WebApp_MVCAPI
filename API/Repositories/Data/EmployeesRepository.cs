using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class EmployeesRepository : IEmployeesRepository
    {
        MyContext myContext;

        public EmployeesRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var dataDelete = Get(id);
            myContext.Employees.Remove(dataDelete);
            var resultDelete = myContext.SaveChanges();
            return resultDelete;
        }

        public List<Employees> Get()
        {
            var dataGet = myContext.Employees.ToList();
            return dataGet;
        }

        public Employees Get(int id)
        {
            var dataGet = myContext.Employees.Find(id);
            return dataGet;
        }

        public int Post(Employees employees)
        {
            myContext.Employees.Add(employees);
            var resultPost = myContext.SaveChanges();
            return resultPost;
        }

        public int Put(Employees employees)
        {
            var dataPut = Get(employees.EmployeeId);
            dataPut.EmployeeName = employees.EmployeeName;
            dataPut.IdJob = employees.IdJob;
            dataPut.Idsalary = employees.Idsalary;
            myContext.Employees.Update(dataPut);
            var resultPut = myContext.SaveChanges();
            return resultPut;
        }
    }
}
