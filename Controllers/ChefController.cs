using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsN.Models;


namespace ChefsN.Controllers
{
    public class ChefController : Controller
    {
        private readonly ILogger<ChefController> _logger;
        private readonly ChefContext _context;

        public ChefController(ILogger<ChefController> logger, ChefContext context)
        {
            _logger = logger;
            _context = context;
        }



//*********Dashboard**********************
        [HttpGet("")]
        public IActionResult Dashboard()
        {
            List<Chef> chefs = _context.Chefs.ToList();
            return View(chefs);
        }





//**********Create************************

        // Create Start Point
        [HttpGet("chefs/new")]
        public ViewResult NewChef()
        {
            return View();
        }


        // Creating new chef
        [HttpPost("chefs/new")] // Fixed the missing action method name
        public IActionResult Create(Chef newChef) //  name to match the form
        {
            if (ModelState.IsValid)
            {
                // Add the new chef to the database
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

                // List<Chef> chefs = _context.Chefs.ToList();  // Redirect to the dashboard and pass the list of chefs to display
                // return View("Dashboard", chefs);
            }

            // If the model state is not valid, return to the create page with validation errors
            return View("NewChef", newChef); // creating a chef is named "NewChef"
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
