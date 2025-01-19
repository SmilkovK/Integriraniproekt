using ProektDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektService.Interface
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAllRest();
        Restaurant GetDetailsForRest(Guid? id);
        void CreateNewRest(Restaurant r);
        void UpdateExistingRest(Restaurant r);
        void DeleteRest(Guid id);
    }
}
