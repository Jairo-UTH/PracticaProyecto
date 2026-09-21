using BackendTienda.Data;
using Microsoft.EntityFrameworkCore;
using BackendTienda.Feautures.Employees;
using BackendTienda.Shared.Database;


namespace BackendTienda.Feautures.Positions
{
    public class PositionService(AppDbContext _db)
    {

        public async Task<IEnumerable<GetPosition>> GetAll()
        {
            var positions = await _db.position.ToListAsync();

            return positions.Select(e => new GetPosition(
                 PositionId: e.PositionId,
                  Name: e.Name
                 )).ToList();
        }
    }
}
