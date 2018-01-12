using System.Collections.Generic;

namespace MyCqrsEsRedisDemo.Domain.ReadModel.Repositories.Interfaces
{
    public interface ILocationRepository : IBaseRepository<LocationRM>
    {
        IEnumerable<LocationRM> GetAll();
        IEnumerable<EmployeeRM> GetEmployees(int locationID);
        bool HasEmployee(int locationID, int employeeID);
    }
}