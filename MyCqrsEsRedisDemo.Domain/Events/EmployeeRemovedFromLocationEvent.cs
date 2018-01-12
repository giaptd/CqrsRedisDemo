using System;

namespace MyCqrsEsRedisDemo.Domain.Events
{
    public class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly int _locationId;
        public readonly int employeeId;

        public EmployeeRemovedFromLocationEvent(Guid id, int locationId, int employeeId)
        {
            this.Id = id;
            _locationId = locationId;
            this.employeeId = employeeId;
        }
    }
}