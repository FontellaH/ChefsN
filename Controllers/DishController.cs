using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsN.Models;


namespace ChefsN.Controllers
{
    public class DishController : Controller
    {
        private readonly ILogger<DishController> _logger;
        private readonly ChefContext _context;

        public DishController(ILogger<DishController> logger, ChefContext context)
        {
            _logger = logger;
            _context = context;
        }





//***************Dashboard******************


[HttpGet("dishes")] // Define the route for the Dish Dashboard
public IActionResult Dashboard()
{
    // Retrieve a list of dishes and pass it to the view

    List<Dish> dishes = _context.Dishes.ToList(); // list of dishs from the database

    // List<Chef> chefs = _context.Dishes.ToList(); //list of chefs from the database

    // ViewBag.Chefs = chefs;
    return View(dishes);
}






//**********Create************************

        // Create Start Point
        [HttpGet("dishes/new")]
        public ViewResult NewDish()
        {
            return View();
        }


        // Creating new Dish
        [HttpPost("dishes/new")] // Fixed the missing action method name
        public IActionResult CreateDish(Dish newDish) //  name to match the form
        {
            if (ModelState.IsValid)
            {
                // Add the new dish to the database
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

                // List<Dish> Dishs = _context.Dishs.ToList();  // Redirect to the dashboard and pass the list of Dishs to display
                // return View("Dashboard", Dishs);
            }

            // If the model state is not valid, return to the create page with validation errors
            return View("NewDish", newDish); // creating a Dish is named "NewChef"
        }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
