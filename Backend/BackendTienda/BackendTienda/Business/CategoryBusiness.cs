using BackendTienda.Data;
using BackendTienda.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackendTienda.Business
{
    public class CategoryBusiness(AppDbContext _db)

    {
        public async Task<List<GetCategoryResponse>> GetAll()
        {
            var cateries = await _db
            .Categories
            .AsNoTracking()
            .Select(e => new GetCategoryResponse(
            e.CategoryId.ToString(),
            e.Icon,
            e.Name
            )).ToListAsync();
            return cateries;
        }
    }

}


