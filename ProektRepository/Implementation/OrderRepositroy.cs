using DeliveryAppRepository;
using Microsoft.EntityFrameworkCore;
using ProektDomain.Domain;
using ProektRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektRepository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.FoodsInOrder)
                .Include(z => z.Owner)
                .Include("FoodsInOrder.Foods")
                .ToList();
        }

        public Order GetDetailsForOrder(Guid? id)
        {
            return entities
                .Include(z => z.FoodsInOrder)
                .Include(z => z.Owner)
                .Include("FoodsInOrder.Foods")
                .SingleOrDefaultAsync(z => z.Id == id).Result;
        }
    }
}
