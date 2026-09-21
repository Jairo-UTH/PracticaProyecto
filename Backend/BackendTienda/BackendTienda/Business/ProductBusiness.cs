using BackendTienda.Data;
using BackendTienda.DTOs;
using BackendTienda.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTienda.Business
{
    public class ProductBusiness
    {
        private AppDbContext _db;
        private IWebHostEnvironment _env;
        private IConfiguration _config;
        private string folder;
        private string uploadsFolder;

        public ProductBusiness(AppDbContext db, IWebHostEnvironment env, IConfiguration config)
        {
            _db = db;
            _env = env;
            _config = config;
            folder = _config["ImageSettings:ProductsFolder"]!;
            uploadsFolder = Path.Combine(_env.WebRootPath, folder);
            Directory.CreateDirectory(uploadsFolder);
        }

        public async Task<int> Create (CreateProductRequest req)
        {
            string extension = Path.GetExtension(req.image.FileName);
            string fileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await req.image.CopyToAsync(stream);
            }

            var eProduct = new Product
            {
                CategoryId = req.categoryId,
                Name = req.name,
                Price = req.price,
                StockQuantity = req.stockQuantity,
                Image = fileName
            };

            await _db.Products.AddAsync(eProduct);
            await _db.SaveChangesAsync();
            return eProduct.ProductId;
        }

        public async Task<List<GetProductResponse>> GetAll(string serverUrl, string categoryId)
        {
            var query = _db.Products.AsNoTracking();

            if (categoryId != "0")
                query = query.Where(p => p.CategoryId == int.Parse(categoryId));

            var products = await query
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new GetProductResponse(
                    p.ProductId,
                    p.CategoryId.ToString(),
                    p.Category.Name,
                    p.Name,
                    p.Price,
                    p.StockQuantity,
                    $"{serverUrl}/{folder}/{p.Image}"
                )).ToListAsync();
            return products;
        }

    }
}
