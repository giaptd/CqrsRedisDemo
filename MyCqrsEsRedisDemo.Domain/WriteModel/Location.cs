using CQRSlite.Domain;
using MyCqrsEsRedisDemo.Domain.Events;
using System;
using System.Collections.Generic;

namespace MyCqrsEsRedisDemo.Domain.WriteModel
{
    public class Location: AggregateRoot
    {
        private int _locationId;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _postalCode;
        private IList<int> _employees;

        public Location(Guid id, int locationId, string streetAddress, string city, string state, string postalCode)
        {
            Id = id;
            _locationId = locationId;
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _employees = new List<int>();

            // todo Raise Event
            var locationCreatedEvent = new LocationCreatedEvent(Id, locationId, streetAddress, city, state, postalCode);
            ApplyChange(locationCreatedEvent);
        }

        public void AddEmployee(int employeeId)
        {
            _employees.Add(employeeId);
            ApplyChange(new EmployeeAssignedToLocationEvent(Id, _locationId, employeeId));
        }

        public void RemoveEmployee(int employeeId)
        {
            _employees.Remove(employeeId);
            ApplyChange(new EmployeeRemovedFromLocationEvent(Id, _locationId, employeeId));
        }

    }
}
