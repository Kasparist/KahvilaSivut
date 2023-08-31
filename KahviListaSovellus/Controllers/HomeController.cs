using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KahviListaSovellus.Models;

namespace KahviListaSovellus.Controllers;

public class HomeController : Controller
{
    private static List<Kahvi> kahvit = new List<Kahvi>(); 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(kahvit);
    }

        [HttpPost]
        public IActionResult Index(string nimi, string hinta, string koko, string laktoositon)
    {

        var newKahvi = new Kahvi()
            {
                Nimi = nimi,
                Hinta = decimal.Parse(hinta),
                Koko = Enum.Parse<KahvinKoko>(koko),
                Laktoositon = laktoositon == "on"
            };

            kahvit.Add(newKahvi);
            return View(kahvit);
    }

    [HttpPost]
    public IActionResult RemoveItem(int Id)
    {
        var ItemsToRemove = kahvit.FirstOrDefault(Kahvi => Kahvi.Id == Id);
        if(ItemsToRemove != null)
        {
            kahvit.Remove(ItemsToRemove);
        }
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Info()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
