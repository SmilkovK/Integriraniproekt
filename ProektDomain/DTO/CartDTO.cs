using ProektDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.DTO
{
    public class CartDTO : BaseEntity
    {
        public List<FoodsInCart>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
