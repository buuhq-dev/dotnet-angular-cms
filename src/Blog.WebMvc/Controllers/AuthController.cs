﻿using Blog.Core.Domain.Identity;
using Blog.Core.SeedWorks.Constants;
using Blog.WebMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebMvc.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    [Route("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [Route("register")]
    public async Task<IActionResult> Register([FromForm] RegsiterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var result = await _userManager.CreateAsync(new AppUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email,
        }, model.Password);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            await _signInManager.SignInAsync(user, true);
            return Redirect(UrlConsts.Profile);
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View();
    }
}
