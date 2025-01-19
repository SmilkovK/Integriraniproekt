using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryAppRepository;
using ProektDomain.Domain;
using System.Security.Claims;
using ProektService.Interface;

namespace Integriraniproekt.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IFoodService _foodsservice;
        private readonly IShoppingCartService _shoppingcartservice;

        public FoodsController(IFoodService foodsservice, IShoppingCartService shoppingcartservice)
        {
            _foodsservice = foodsservice;
            _shoppingcartservice = shoppingcartservice;
        }

        public IActionResult Index()
        {
            return View(_foodsservice.GetAllFoods());
        }

        // GET: Foods/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodsservice.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price,Image,Id")] Food food)
        {
            if (ModelState.IsValid)
            {
                food.Id = Guid.NewGuid();
                _foodsservice.CreateNewFood(food);
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodsservice.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Description,Price,Image,Id")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _foodsservice.UpdateExistingFood(food);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodsservice.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _foodsservice.DeleteFood(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodsservice.GetDetailsForFood(id);

            FoodsInCart ps = new FoodsInCart();

            if (food != null)
            {
                ps.FoodId = food.Id;
            }

            return View(ps);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(FoodsInCart model)
        {
            if (model == null || model.FoodId == Guid.Empty)
            {
                return BadRequest("Food information is missing.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            _shoppingcartservice.AddToShoppingConfirmed(model, userId);

            return View("Index", _foodsservice.GetAllFoods());
        }
    }
}
