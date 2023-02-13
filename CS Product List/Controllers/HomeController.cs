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
        return View(ProductDAL.GetAll());
    }

    //public IActionResult Index()
    //{
    //    List<Product> result = dbContext.Products.ToList();
    //    return View(result);
    //}

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ProductDetails(int id)
    {
        return View(ProductDAL.GetById(id));
    }

    //public IActionResult ProductDetails(int id)
    //{
    //    Product result = dbContext.Products.FirstOrDefault(p => p.Id == id); //.Find(id)
    //    return View(result);
    //}

    public IActionResult Categories()
    {
        return View(ProductDAL.GetAllCategories());
    }

    public IActionResult ProductsByCategory(string category)
    {
        return View(ProductDAL.GetAllByCategory(category));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

