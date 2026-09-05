using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject1.Context;
using MVCProject1.Models;

namespace MVCProject1.Controllers;

public class PlanController : Controller
{
    // set up connection to the database using dependency injection
    private readonly GymDbContext DbContext;
    public PlanController()
    {
        DbContext = new GymDbContext();
    }

    // GET:: url/Plan/Index => get all plans
    // get data from DB (Heavy) => Async
    public async Task<ActionResult<Plan>> Index()
    {
        var plans = await DbContext.Plans.ToListAsync();
        return View(plans);
    }

    //Get :: BaseURL/Plan/Details/@Id => get plan details by id
    [HttpGet]
    public async Task<ActionResult<Plan>> Details(int id)
    {
        var plan = await DbContext.Plans.FindAsync(id);
        if (plan == null)
            return RedirectToAction(nameof(Index));
        return View(plan);
    }

}
