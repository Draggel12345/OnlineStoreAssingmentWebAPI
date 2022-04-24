using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assingment.Models.Category;
using StoreWebAPI_Assingment.Models.Data;
using StoreWebAPI_Assingment.Models.Order;
using StoreWebAPI_Assingment.Models.Product;
using StoreWebAPI_Assingment.Models.User;

namespace StoreWebAPI_Assingment.Services
{
    public interface IOrderService
    {
        //CRUD
        public Task<Order> CreateOrderAsync(Guid id, List<ProductModel> cart);
        public Task<IEnumerable<OrderEntity>> GetOrdersAsync();
        public Task<OrderEntity> GetOrderAsync(Guid id);
        public Task<Order> UpdateOrderAsync(Guid userId, OrderRowUpdate orderRow);
        public Task<bool> DeleteOrderAsync(Guid id);
    }

    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrderAsync(Guid id, List<ProductModel> cart)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userEntity != null)
            {

                var orderEntity = new OrderEntity
                {
                    CustomerId = id,
                    CustomerName = $"{userEntity.FirstName} {userEntity.LastName}",
                    Address = $"{userEntity.Country} {userEntity.City} {userEntity.StreetAddress} {userEntity.ZipCode}",
                    OrderDate = DateTime.Now,
                    OrderStatus = "Shipping...",
                };


                var orderRows = new List<OrderRowEntity>();
                foreach (var item in cart)
                {
                    orderRows.Add(new OrderRowEntity
                    {
                        OrderId = orderEntity.Id,
                        ArticleNumber = item.ArticleNumber,
                        ProductName = item.Name,
                        Quantity = cart.Count,
                        ProductPrice = item.Price,
                    });
                }

                orderEntity.OrderRows = orderRows;

                _context.Add(orderEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Order>(orderEntity);
            }

            return null!;
        }

        public async Task<IEnumerable<OrderEntity>> GetOrdersAsync()
        {
            return await _context.Orders.Include(x => x.OrderRows).ToListAsync();
        }

        public async Task<OrderEntity> GetOrderAsync(Guid id)
        {
            var order = await _context.Orders.Include(x => x.OrderRows).FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                return order;

            }

            return null!;
        }

        public async Task<Order> UpdateOrderAsync(Guid userId, OrderRowUpdate orderRow)
        {
            var userEntity = await _context.Users.FindAsync(userId);
            if (userEntity != null)
            {
                var orderEntity = await _context.Orders.FirstOrDefaultAsync(x => x.CustomerId == userEntity.Id);
                if (orderEntity != null)
                {
                    var orderRowEntity = await _context.OrderRows.FirstOrDefaultAsync(x => x.OrderId == orderEntity.Id);
                    if (orderRowEntity != null)
                    {
                        if (orderRowEntity.ProductName != orderRow.ProductName && !string.IsNullOrEmpty(orderRow.ProductName))
                            orderRowEntity.ProductName = orderRow.ProductName;

                        if (orderRowEntity.ProductName != orderRow.ProductName && orderRow.Quantity != 0)
                            orderRowEntity.Quantity = orderRow.Quantity;

                        if (orderRowEntity.ProductPrice != orderRow.ProductPrice && orderRow.ProductPrice != 0)
                            orderRowEntity.ProductPrice = orderRow.ProductPrice;
                    }

                    _context.Entry(orderEntity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return _mapper.Map<Order>(orderEntity);
                }
            }

            return null!;
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity != null)
            {
                var orderRowEntity = await _context.OrderRows.FirstOrDefaultAsync(x => x.OrderId == id);
                if (orderRowEntity != null)
                {
                    _context.OrderRows.Remove(orderRowEntity);
                    _context.Orders.Remove(orderEntity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
