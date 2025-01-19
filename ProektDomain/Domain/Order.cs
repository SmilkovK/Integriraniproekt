using ProektDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.Domain
{
    public class Order : BaseEntity
    {
        public string? userId { get; set; }
        public DeliveryUser? Owner { get; set; }
        public ICollection<FoodsInOrder>? FoodsInOrder { get; set; }
    }
}
