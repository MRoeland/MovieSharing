using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieSharing.Data;
using VideotheekWebApp.Models;

namespace MovieSharing.Controllers
{
    [Authorize(Roles = "admin")]
    public class LedenController : Controller
    {
        private readonly UserManager<Lid> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Lid> _signInManager;

        public LedenController(UserManager<Lid> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Lid> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: Leden
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                var users = _userManager.Users.Where(f => f.UserName.Contains(searchString) && f.Deleted == false);
                return View(await users.ToListAsync());
            }
            else
            {
                var users = _userManager.Users.Where(c => c.Deleted == false);
                return View(await users.ToListAsync());
            }
        }

        // GET: Leden/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var allRoles = _roleManager.Roles.ToList();
            ViewBag.AllRoles = allRoles.Select(r => r.Name).ToList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Lid { UserName = model.UserName, Email = model.Email };
                user.Voornaam = model.Voornaam;
                user.Achternaam = model.Achternaam;
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, model.Password);

                var resultAddRoles = await _userManager.AddToRolesAsync(user, model.Roles);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var allRoles = _roleManager.Roles.ToList();
            ViewBag.AllRoles = allRoles.Select(r => r.Name).ToList();

            return View(model);
        }

        // GET: Leden/Details
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Leden/Edit
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Voornaam = user.Voornaam,
                Achternaam = user.Achternaam,
                Roles = userRoles.ToList()
            };

            var allRoles = _roleManager.Roles.ToList();
            ViewBag.AllRoles = allRoles.Select(r => r.Name).ToList();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Voornaam = model.Voornaam;
                    user.Achternaam = model.Achternaam;

                    // Update user roles
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var resultRemoveRoles = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    var resultAddRoles = await _userManager.AddToRolesAsync(user, model.Roles);

                    if (resultRemoveRoles.Succeeded && resultAddRoles.Succeeded)
                    {
                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            if (!User.IsInRole("admin"))
                                return RedirectToAction("Logout");

                            return RedirectToAction("Index");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    else
                    {
                        foreach (var error in resultRemoveRoles.Errors.Concat(resultAddRoles.Errors))
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
            }

            // Get all available roles for the dropdown list
            var allRoles = _roleManager.Roles.ToList();
            ViewBag.AllRoles = allRoles.Select(r => r.Name).ToList();

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: Leden/Delete
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new DeleteUserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                //var result = await _userManager.DeleteAsync(user);
                user.Deleted = true;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Index");
        }
    }
}

