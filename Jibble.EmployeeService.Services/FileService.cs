

namespace Jibble.EmployeeService.Services
{
    public class FileService : IFileService
    {
        public List<UploadEmployeeCsvRequest> ReadEmployeeCsv(Stream stream)
        {
            var employees = new List<UploadEmployeeCsvRequest>();
            using var textReader = new StreamReader(stream);
            using var reader = new CsvReader(textReader, CultureInfo.InvariantCulture);

            reader.Read();
            reader.ReadHeader();

            while (reader.Read())
            {
                var emp = new UploadEmployeeCsvRequest()
                {
                    ReferenceId = reader.GetField<int>("Emp ID"),
                    FirstName = reader.GetField("First Name"),
                    LastName = reader.GetField("Last Name")
                };

                DateTime dob;
                if (DateTime.TryParse(reader.GetField("Date of Birth"), out dob))
                    emp.DateOfBirth = dob;

                employees.Add(emp);
            }

            return employees;
        }
    }
}