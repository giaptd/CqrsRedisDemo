using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CQRSlite.Events;
using MyCqrsEsRedisDemo.Domain.Events;
using MyCqrsEsRedisDemo.Domain.ReadModel;
using MyCqrsEsRedisDemo.Domain.ReadModel.Repositories.Interfaces;

namespace MyCqrsEsRedisDemo.Domain.EventHandlers
{
    public class EmployeeEventHandler: IEventHandler<EmployeeCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeEventHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public Task Handle(EmployeeCreatedEvent message)
        {
            EmployeeRM employeeRM = _mapper.Map<EmployeeRM>(message);
            _employeeRepository.Save(employeeRM);
            return Task.CompletedTask;
        }
    }
}
