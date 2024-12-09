using Blog.Core.Domain.Identity;
using Blog.Core.SeedWorks.Constants;
using Blog.Core.SeedWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Blog.Core.SeedWorks.Constants.Permissions;
using Blog.WebMvc.Extensions;
using Blog.WebMvc.Models;
using Microsoft.AspNetCore.Authentication;

namespace Blog.WebMvc.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    public ProfileController(IUnitOfWork unitOfWork,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [Route("/profile")]
    public async Task<IActionResult> Index()
    {
        var userId = User.GetUserId();
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        return View(new ProfileViewModel()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        });
    }

    [HttpGet]
    [Route("/profile/edit")]
    public async Task<IActionResult> ChangeProfile()
    {
        var userId = User.GetUserId();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        return View(new ChangeProfileViewModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName
        });
    }

    [Route("/profile/edit")]
    [HttpPost]
    public async Task<IActionResult> ChangeProfile([FromForm] ChangeProfileViewModel model)
    {
        var userId = User.GetUserId();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            TempData["Success"] = "Update profile successful.";
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Update profile failed");

        }
        return View(model);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        await HttpContext.SignOutAsync();

        return Redirect(UrlConsts.Home);
    }
}
