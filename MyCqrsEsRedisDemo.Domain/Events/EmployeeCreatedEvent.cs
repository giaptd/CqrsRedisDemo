using System;

namespace MyCqrsEsRedisDemo.Domain.Events
{
    public class EmployeeCreatedEvent: BaseEvent
    {
        public readonly int EmployeeId;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string JobTitle;
        public readonly DateTime DateOfBirth;

        public EmployeeCreatedEvent(Guid id, int employeeId, string firstName, string lastName, string jobTitle, DateTime dateOfBirth)
        {
            Id = id;
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            DateOfBirth = dateOfBirth;
        }
    }
}
