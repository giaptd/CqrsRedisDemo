using CQRSlite.Commands;
using CQRSlite.Domain;
using MyCqrsEsRedisDemo.Domain.Commands;
using MyCqrsEsRedisDemo.Domain.WriteModel;
using System.Threading.Tasks;

namespace MyCqrsEsRedisDemo.Domain.CommandHandlers
{
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly ISession _session;

        public EmployeeCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateEmployeeCommand command)
        {
            Employee employee = new Employee(command.Id, command.EmployeeId, command.FirstName, command.LastName,
                command.DateOfBirth.Date, command.JobTitle);
            await _session.Add(employee);
            await _session.Commit();
        }
    }
}