using System.Diagnostics;
using FluentValidation;
using HumanResourceDictionary.Application.Services.Dictionaries.City;
using HumanResourceDictionary.Application.Services.Dictionaries.Gender;
using HumanResourceDictionary.Application.Services.Users.AddUser;
using HumanResourceDictionary.Application.Services.Users.AddUser.Models;
using HumanResourceDictionary.Application.Services.Users.GetUsers;
using HumanResourceDictionary.Domain.UserModels;
using Microsoft.AspNetCore.Mvc;
using HumanResourceDictionary.MVC.Models;

namespace HumanResourceDictionary.MVC.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="genderServices"></param>
/// <param name="cityServices"></param>
/// <param name="getUsersService"></param>
/// <param name="addUserService"></param>
public class HomeController(
    ILogger<HomeController> logger,
    IGenderServices genderServices,
    ICityServices cityServices,
    IGetUsersService getUsersService,
    IAddUserService addUserService,
    IValidator<UserDto> userValidator)
    : Controller
{
    /// <summary>
    /// Home page, get users list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var users = await getUsersService.Execute(cancellationToken);
        return View(users.Data);
    }

    [HttpPost("Home/Create")]
    public async Task<IActionResult> Create([FromBody] UserDto user, CancellationToken cancellationToken)
    {
        var validationResult = await userValidator.ValidateAsync(user, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ArgumentException(string.Join(",", validationResult.Errors));
        }

        ;
        var requestModel = new NewUserAddModel()
        {
            User = user
        };
        await addUserService.Execute(requestModel, cancellationToken);
        return Ok(new { success = true });
    }

    [HttpGet("Home/GetCities")]
    public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
    {
        var cities = await cityServices.GetCities(cancellationToken);
        return Json(cities.Data);
    }


    [HttpPost("Home/AddnewUser")]
    public async Task<IActionResult> AddnewUser(NewUserAddModel request, CancellationToken cancellationToken)
    {
        await addUserService.Execute(request, cancellationToken);
        return Ok();
    }

    [HttpGet("Home/GetGenders")]
    public async Task<IActionResult> GetGenders(CancellationToken cancellationToken)
    {
        var genders = await genderServices.GetGenders(cancellationToken);
        return Json(genders.Data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}