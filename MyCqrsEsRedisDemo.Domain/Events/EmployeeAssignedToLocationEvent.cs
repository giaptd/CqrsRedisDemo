using MyCqrsEsRedisDemo.Domain.Events;
using System;

namespace MyCqrsEsRedisDemo.Domain.WriteModel
{
    public class EmployeeAssignedToLocationEvent : BaseEvent
    {
        public readonly int _locationId;
        public readonly int _employeeId;

        public EmployeeAssignedToLocationEvent(Guid id, int locationId, int employeeId)
        {
            Id = id;
            _locationId = locationId;
            _employeeId = employeeId;
        }
    }
}