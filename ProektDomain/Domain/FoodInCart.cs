using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.Domain
{
    public class FoodsInCart : BaseEntity
    {
        public Guid FoodId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Food? Foods { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
