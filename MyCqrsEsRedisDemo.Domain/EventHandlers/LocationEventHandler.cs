using AutoMapper;
using CQRSlite.Events;
using MyCqrsEsRedisDemo.Domain.Events;
using MyCqrsEsRedisDemo.Domain.ReadModel;
using MyCqrsEsRedisDemo.Domain.ReadModel.Repositories.Interfaces;
using MyCqrsEsRedisDemo.Domain.WriteModel;
using System.Threading.Tasks;

namespace MyCqrsEsRedisDemo.Domain.EventHandlers
{
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>,
                                        IEventHandler<EmployeeAssignedToLocationEvent>,
                                        IEventHandler<EmployeeRemovedFromLocationEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public LocationEventHandler(IMapper mapper, ILocationRepository locationRepository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _employeeRepository = employeeRepository;
        }

        public Task Handle(LocationCreatedEvent message)
        {
            var locationRM = _mapper.Map<LocationRM>(message);
            _locationRepository.Save(locationRM);
            return Task.CompletedTask;
        }

        public Task Handle(EmployeeAssignedToLocationEvent message)
        {
            var location = _locationRepository.GetByID(message._locationId);
            location.Employees.Add(message._employeeId);
            _locationRepository.Save(location);

            //Find the employee which was assigned to this Location
            var employee = _employeeRepository.GetByID(message._employeeId);
            employee.LocationID = message._locationId;
            _employeeRepository.Save(employee);
            return Task.CompletedTask;
        }

        public Task Handle(EmployeeRemovedFromLocationEvent message)
        {
            var location = _locationRepository.GetByID(message._locationId);
            location.Employees.Remove(message.employeeId);
            _locationRepository.Save(location);
            return Task.CompletedTask;
        }
    }
}
