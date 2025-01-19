using ProektDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektRepository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<DeliveryUser> GetAll();
        DeliveryUser Get(string? id);
        void Insert(DeliveryUser entity);
        void Update(DeliveryUser entity);
        void Delete(DeliveryUser entity);
    }
}
