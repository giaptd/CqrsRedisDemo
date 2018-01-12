using System.Collections.Generic;

namespace MyCqrsEsRedisDemo.Domain.ReadModel.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeRM>
    {
        IEnumerable<EmployeeRM> GetAll();
    }
}