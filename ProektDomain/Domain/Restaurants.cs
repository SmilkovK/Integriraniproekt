using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.Domain
{
    public class Restaurant : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Raiting { get; set; }
        public string? ImageUrl { get; set; }
    }
}
