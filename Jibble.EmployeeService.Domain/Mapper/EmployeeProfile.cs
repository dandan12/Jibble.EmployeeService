namespace Jibble.EmployeeService.Domain.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<UploadEmployeeCsvRequest, Employee>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ReverseMap();
        }
    }
}
