using System.Diagnostics;
using HumanResourceDictionary.Application.Services.Dictionaries.Gender;
using Microsoft.AspNetCore.Mvc;
using HumanResourceDictionary.MVC.Models;

namespace HumanResourceDictionary.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IGenderServices _genderServices;

    public HomeController(ILogger<HomeController> logger, IGenderServices genderServices)
    {
        _logger = logger;
        _genderServices = genderServices;
    }

    public async Task<IActionResult> Index()
    {
        var genders = await _genderServices.GetGenders(default);
        return View();
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