using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CS_Product_List.Models;

namespace CS_Product_List.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //Allow access to the database
    private ProductListContext dbContext = new ProductListContext();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ProductView()
    {
        List<Product> result = dbContext.Products.ToList();
        return View(result);
    }

    public IActionResult ProductDetails(int id)
    {
        Product result = dbContext.Products.FirstOrDefault(p => p.Id == id);
        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

