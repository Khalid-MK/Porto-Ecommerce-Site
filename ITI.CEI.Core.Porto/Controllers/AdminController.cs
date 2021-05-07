using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITI.CEI.Core.Porto.Core;
using ITI.CEI.Core.Porto.Models;
using ITI.CEI.Core.Porto.Models.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.CEI.Core.Porto.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminController : Controller
    {

        private IUnitOfWork unitOfWork;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public ActionResult ManageRoles()
        {

            AdminViewModel adminViewModel = new AdminViewModel()
            {
                Roles = _roleManager.Roles.ToList(),
            };


            return View(adminViewModel);
        }

        // GET: Admin/Create
        public ActionResult ManageCategroies()
        {
            AdminViewModel adminViewModel = new AdminViewModel()
            {
                CategoryRequests = unitOfWork.CategoryRequestManager.GetAll().ToList(),
                Users = _userManager.Users.ToList(),
            };

            return View(adminViewModel);
        }


        public bool CreateFromRequest(int id)
        {
            var request = unitOfWork.CategoryRequestManager.GetById(id);
            if (request != null)
            {
                Category category = new Category()
                {
                    Name = request.Title,
                    Description = request.Description,
                };
                unitOfWork.CategoryManager.Add(category);
                ViewBag.Message = "Category Added Successfuly";
                unitOfWork.CategoryRequestManager.Delete(request);
                return true;

            }
            return false;
        }

        [HttpPost]
        public ActionResult CreateCategory(AdminViewModel adminViewModel)
        {
            if (adminViewModel.Category != null)
            {
                unitOfWork.CategoryManager.Add(adminViewModel.Category);

                adminViewModel = new AdminViewModel()
                {
                    CategoryRequests = unitOfWork.CategoryRequestManager.GetAll().ToList(),
                    Users = _userManager.Users.ToList(),
                };

                ViewBag.Message = "Category Added Successfully.";

                return View("ManageCategroies", adminViewModel);
            }

            ViewBag.Message = "Faild to add Category.";

            return View("ManageCategroies", adminViewModel);
        }


        [HttpGet]
        public bool DeleteRequest(int id)
        {
            var request = unitOfWork.CategoryRequestManager.GetById(id);
            if (request != null)
            {
                unitOfWork.CategoryRequestManager.Delete(request);
                ViewBag.Message = "Request Deleted Successfuly";
                return true;

            }
            return false;
        }



        public async Task<IActionResult> AddRole(AdminViewModel adminViewModel)
        {
            if (!await _roleManager.RoleExistsAsync(adminViewModel.Role.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(adminViewModel.Role.Name));
            }

            AdminViewModel adminVM = new AdminViewModel()
            {
                Roles = _roleManager.Roles.ToList(),
            };

            return View("ManageRoles",adminVM);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            await _roleManager.DeleteAsync(role);

            AdminViewModel adminVM = new AdminViewModel()
            {
                Roles = _roleManager.Roles.ToList(),
            };

            return View("ManageRoles", adminVM);
        }


    }
}