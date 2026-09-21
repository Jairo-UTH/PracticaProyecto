using BackendTienda.Data;
using BackendTienda.Entities;
using Microsoft.EntityFrameworkCore;
using static BackendTienda.DTOs.OrderDTOs;

namespace BackendTienda.Business
{
    public class OrderBusiness
    {
        private AppDbContext _db;
        private IConfiguration _config;

        private string folder;

        public OrderBusiness(AppDbContext db, IWebHostEnvironment env, IConfiguration config)
        {
            _db = db;
            _config = config;
            folder = _config["ImageSettings:ProductsFolder"]!;
        }

        public async Task<int> Create(CreateOrderRequest req)
        {
            foreach (var product in req.details)
            {
                var productFound = await _db.Products.FindAsync(product.productId);
                productFound!.StockQuantity -= product.quantity;
            }
            var eOrder = new Order
            {
                TotalAmount = req.totalAmount,
                OrderDetails = req.details.Select(d => new OrderDetail
                {
                    ProductId = d.productId,
                    Quantity = d.quantity,
                    UnitPrice = d.unitPrice,
                }).ToList(),
            };

            await _db.Orders.AddAsync(eOrder);
            await _db.SaveChangesAsync();

            return eOrder.OrderId;
        }

        public async Task<IEnumerable<GetOrderResponse>> GetAll(string serverUrl)
        {
            return await _db.Orders
                .AsNoTracking()
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new GetOrderResponse(
                    o.OrderId,
                    o.OrderDate.ToString("dd/MM/yyyy HH:mm:ss"),
                    o.TotalAmount,
                    details: o.OrderDetails.Select(od => new GetOrderDetailResponse(
                        $"{serverUrl}/{folder}/{od.Product.Image!}",
                        od.Product.Name,
                        od.Quantity,
                        od.Quantity * od.UnitPrice
                    ))
                )).ToListAsync();
        }

    }
}