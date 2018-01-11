using CQRSlite.Domain;
using MyCqrsEsRedisDemo.Domain.Events;
using System;

namespace MyCqrsEsRedisDemo.Domain.WriteModel
{
    public class Employee : AggregateRoot
    {
        private int _employeeId;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _jobTitle;

        public Employee()
        {
            
        }

        public Employee(Guid id, int employeeId, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            _employeeId = employeeId;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _jobTitle = jobTitle;

            // todo Apply Events
            // Raise event
            var employeeCreatedEvent =
                new EmployeeCreatedEvent(id, employeeId, firstName, lastName, jobTitle, dateOfBirth);
            ApplyChange(employeeCreatedEvent);
        }
    }
}
