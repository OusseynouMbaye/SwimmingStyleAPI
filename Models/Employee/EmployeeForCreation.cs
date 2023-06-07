namespace SwimmingStyleAPI.Models.Employee
{
    public class EmployeeForCreation
    {
        //public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
