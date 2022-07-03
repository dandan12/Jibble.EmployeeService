using AutoMapper;
using Jibble.EmployeeService.Domain.Utils;
using Jibble.EmployeeService.Repository.Interface;

namespace Jibble.EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<Employee>> IntersectEmployeeFromSource(List<UploadEmployeeCsvRequest> requests)
        {
            var mappedEmployeeRequests = _mapper.Map<List<Employee>>(requests);

            var employeeIds = mappedEmployeeRequests.Select(x => x.ReferenceId).ToArray();
            var entities = _employeeRepository.Contains(employeeIds);

            var except = mappedEmployeeRequests.Except(entities, new EmployeeEqualityComparer()).ToList();
            var intersect = entities.Intersect(mappedEmployeeRequests, new EmployeeEqualityComparer()).ToList();
            var requestIntersect = mappedEmployeeRequests.Intersect(intersect, new EmployeeEqualityComparer()).ToList();

            intersect = intersect.OrderBy(x => x.ReferenceId).ToList();
            requestIntersect = requestIntersect.OrderBy(x => x.ReferenceId).ToList();

            for (var i = 0; i < intersect.Count; i++)
            {
                var _intersect = intersect[i];
                var _requestIntersect = requestIntersect[i];

                _mapper.Map(_requestIntersect, _intersect);
            }

            if (except.Any())
                intersect.AddRange(except);

            await _employeeRepository.Upsert(intersect.ToArray());

            return intersect;
        }
    }
}
