namespace BackendTienda.Feautures.Employees
{
    public record GetEmployee(
        int employeeId,
         string fullName,
         string email,
         DateOnly birthDate,
         int positionId,
         string position
        );
}
