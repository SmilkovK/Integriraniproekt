using ProektDomain.Domain;
using ProektRepository.Interface;
using ProektService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektService.Implementation
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _foodsservice;

        public FoodService(IRepository<Food> foodsservice)
        {
            _foodsservice = foodsservice;
        }
        public void CreateNewFood(Food f)
        {
            _foodsservice.Insert(f);
        }

        public void DeleteFood(Guid id)
        {
            var food = _foodsservice.Get(id);
            _foodsservice.Delete(food);
        }

        public List<Food> GetAllFoods()
        {
            return _foodsservice.GetAll().ToList();
        }

        public Food GetDetailsForFood(Guid? id)
        {
            var restaurant = _foodsservice.Get(id);
            return restaurant;
        }

        public void UpdateExistingFood(Food f)
        {
            _foodsservice.Update(f);
        }
    }
}
