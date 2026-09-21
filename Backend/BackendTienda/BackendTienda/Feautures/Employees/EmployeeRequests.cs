namespace BackendTienda.Feautures.Employees
{
    public record CreateEmployee(
        string fullName,
        string email,
        DateOnly birthDate,
        int positionId
        );

    public record UpdateEmployee(
       int employeeId,
       string fullName,
       string email,
       DateOnly birthDate,
       int positionId
       );
}
