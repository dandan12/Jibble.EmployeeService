namespace Jibble.EmployeeService.Domain.Mapper
{
    public class ModelMapper
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new EmployeeProfile());
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
