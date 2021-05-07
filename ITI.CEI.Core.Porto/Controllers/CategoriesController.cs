using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class Categories : Controller
    {
        private IUnitOfWork unitOfWork;

        private readonly UserManager<ApplicationUser> _userManager;

        public Categories(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            _userManager = userManager;

        }


        public ActionResult IndexAPI()
        {

            IEnumerable<Category> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44374/api/");
                var responseTask = client.GetAsync("CategoryAPIController");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Category>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    categories = Enumerable.Empty<Category>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }

            return View(categories);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Categories = unitOfWork.CategoryManager.GetAll().ToList(),
                Tags = unitOfWork.TagManager.GetAll().ToList(),
                UserID = _userManager.GetUserId(HttpContext.User),
            };
            return View(categoryViewModel);
           // return View();
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}