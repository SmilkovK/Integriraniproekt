using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.Domain
{
    public class FoodsInOrder : BaseEntity
    {
        public Guid FoodId { get; set; }
        public Food? Foods { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }

    }
}
