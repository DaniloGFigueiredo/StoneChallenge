using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeeRepository (IEmployeeRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employeeCollection = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }
        public Employee CreateEmployee(Employee employee)
        {
            try
            {
                _employeeCollection.InsertOne(employee);

                return employee;
            }
            catch 
            {
                throw;
            }
           ;
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees() => _employeeCollection.Find(e => true).ToList();  

    }
}
