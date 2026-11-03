using Microsoft.AspNetCore.Mvc;
using ZewelryStore.Data;
using ZewelryStore.Models;

namespace ZewelryStore.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredients;
        public IngredientController(ApplicationDbContext context)
        {
            ingredients = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await ingredients.GetAllAsync());
        }
    }
}
