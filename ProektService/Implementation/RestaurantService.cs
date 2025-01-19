using ProektDomain.Domain;
using ProektService.Interface;
using ProektRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektService.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantservice;
        private readonly IRepository<Food> _foodservice;

        public RestaurantService(IRepository<Restaurant> restaurantservice, IRepository<Food> foodservice)
        {
            _restaurantservice = restaurantservice;
            _foodservice = foodservice;
        }


        public void CreateNewRest(Restaurant r)
        {
            _restaurantservice.Insert(r);
        }

        public void DeleteRest(Guid id)
        {
            var product = _restaurantservice.Get(id);
            _restaurantservice.Delete(product);
        }

        public List<Restaurant> GetAllRest()
        {
            return _restaurantservice.GetAll().ToList();
        }

        public Restaurant GetDetailsForRest(Guid? id)
        {
            var restaurant = _restaurantservice.Get(id);
            return restaurant;
        }

        public void UpdateExistingRest(Restaurant r)
        {
            _restaurantservice.Update(r);
        }

    }
}
