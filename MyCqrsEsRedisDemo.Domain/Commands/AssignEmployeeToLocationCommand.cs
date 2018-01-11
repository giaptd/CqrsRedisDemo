namespace MyCqrsEsRedisDemo.Domain.Commands
{
    public class AssignEmployeeToLocationCommand: BaseCommand
    {
        public readonly int EmployeeId;
        public readonly int LocationId;

        public AssignEmployeeToLocationCommand(int employeeId, int locationId)
        {
            EmployeeId = employeeId;
            LocationId = locationId;
        }
    }
}
