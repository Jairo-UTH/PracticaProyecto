namespace BackendTienda.Shared.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public DateOnly birthDate { get; set; }

        public int positionId { get; set; }
        public virtual Position position { get; set; }
    }
}
