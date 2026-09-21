using BackendTienda.Data;
using BackendTienda.Shared.Models;
using BackendTienda.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace BackendTienda.Feautures.Employees
{
    public class EmployeeService(AppDbContext _db)
    {
        public async Task<IEnumerable<GetEmployee>> GetAll()
        {
            var employees = await _db.employee.Include(p => p.Position).ToListAsync();

            return employees.Select(e => new GetEmployee(
                 employeeId: e.EmployeeId,
                  fullName: e.FullName,
                     email: e.Email,
                     birthDate: e.BirthDate,
                     positionId: e.PositionId,
                     position: e.Position.Name
                 )).ToList();
        }

        public async Task<GetEmployee> GetById(int Id)
        {
            var e = await _db.employee.Include(p => p.Position)
                .FirstAsync(e => e.EmployeeId == Id);

            return new GetEmployee(
                 employeeId: e.EmployeeId,
                  fullName: e.FullName,
                     email: e.Email,
                     birthDate: e.BirthDate,
                     positionId: e.PositionId,
                     position: e.Position.Name
                 );
        }

        public async Task Add(CreateEmployee request)
        {

            var employee = new Employee()
            {
                fullName = request.fullName,
                email = request.email,
                birthDate = request.birthDate,
                positionId = request.positionId
            };

            await _db.employee.AddAsync(employee);
            await _db.SaveChangesAsync();

        }

        public async Task Update(UpdateEmployee request)
        {
            var employeeFound = await _db.employee.FirstAsync(e => e.employeeId == request.employeeId);

            employeeFound.FullName = request.fullName;
            employeeFound.Email = request.email;
            employeeFound.BirthDate = request.birthDate;
            employeeFound.PositionId = request.positionId;

            await _db.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var employeeFound = await _db.employee.FirstAsync(e => e.employeeId == id);

            _db.employee.Remove(employeeFound);
            await _db.SaveChangesAsync();

        }

    }
}
