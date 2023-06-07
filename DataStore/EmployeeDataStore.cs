using SwimmingStyleAPI.Models.Employee;

namespace SwimmingStyleAPI.DataStore
{
    public class EmployeeDataStore
    {

        public List<EmployeeDto> Employees { get; set; }
        // add static property
        public static EmployeeDataStore Current { get; } = new EmployeeDataStore();

        readonly List<int> ID = new List<int> { 1, 2, 3 };
        public EmployeeDataStore()
        {
            Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Id = ID[0],
                    Name = $"Employe{ID[0]}",
                    Email = $"employe{ID[0]}@hotmail.com",
                    Role = "RoleEmploye1"
                },
                new EmployeeDto()
                {
                    Id = 2,
                    Name = $"Employe2",
                    Email = "employe2@hotmail.com",
                    Role = "RoleEmploye2"
                },
                new EmployeeDto()
                {
                    Id = 3,
                    Name = "Employe3",
                    Email = "employe3@hotmail.com",
                    Role = "RoleEmploye3"
                },

            };
        }
    }
}
