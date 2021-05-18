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
        public EmployeeRepository(IEmployeeRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employeeCollection = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }
        public List<Employee> CreateManyEmployees(List<Employee> employees)
        {
            try
            {
                _employeeCollection.InsertMany(employees);

                return employees;
            }
            catch
            {
                throw;
            }
        }
        public Employee GetEmployeeByRegistrationNumberAndName(long registrationNumber, string name) => _employeeCollection.Find(e =>
        (e.RegistrationNumber == registrationNumber) &&
        (e.Name == name)).FirstOrDefault();
        public List<Employee> GetAllEmployees() => _employeeCollection.Find(e => true).ToList();
        public void DeleteEmployeeByRegistrationNumberAndName(long registrationNumber, string name) => _employeeCollection.FindOneAndDelete(e =>
         (e.RegistrationNumber == registrationNumber) &&
         (e.Name == name));
    }
}
