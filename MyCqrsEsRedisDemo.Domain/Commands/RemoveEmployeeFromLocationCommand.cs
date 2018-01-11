namespace MyCqrsEsRedisDemo.Domain.Commands
{
    public class RemoveEmployeeFromLocationCommand : BaseCommand
    {
        public readonly int EmployeeId;
        public readonly int LocationId;

        public RemoveEmployeeFromLocationCommand(int employeeId, int locationId)
        {
            EmployeeId = employeeId;
            LocationId = locationId;
        }
    }
}