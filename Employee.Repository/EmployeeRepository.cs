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
        public async Task< List<Employee>> CreateManyEmployees(List<Employee> employees)
        {
            try
            {
              await  _employeeCollection.InsertManyAsync(employees);

                return employees;
            }
            catch
            {
                throw;
            }
        }
        public async Task <Employee> GetEmployeeByRegistrationNumberAndName(long registrationNumber, string name) => await  _employeeCollection.Find( e =>
        (e.RegistrationNumber == registrationNumber) &&
        (e.Name == name)).FirstOrDefaultAsync();

        public async Task <List<Employee>> GetAllEmployees() =>  await _employeeCollection.Find ( e => true).ToListAsync();
        public async Task<Employee> DeleteEmployeeByRegistrationNumberAndName(long registrationNumber, string name) => await _employeeCollection.FindOneAndDeleteAsync(e =>
         (e.RegistrationNumber == registrationNumber) &&
         (e.Name == name));
    }
}
