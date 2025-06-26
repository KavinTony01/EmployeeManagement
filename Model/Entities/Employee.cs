namespace EmployeeManagementPortal.Model.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Location { get; set; }
        public long Mobile { get; set; }
        public bool IsActive { get; set; }
    }
}
