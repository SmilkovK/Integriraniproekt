using ProektDomain.api_domain;
using ProektDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektDomain.api_domain
{
    public class Book : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Year { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
    }
}
