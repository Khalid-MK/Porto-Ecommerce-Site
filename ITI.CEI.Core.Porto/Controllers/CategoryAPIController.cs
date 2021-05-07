using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ITI.CEI.Core.Porto.Core;
using ITI.CEI.Core.Porto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.CEI.Core.Porto.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public CategoryAPIController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/CategoryAPI
        public List<Category> GetAllCategories()
        {
            List<Category> categories = unitOfWork.CategoryManager.GetAll().ToList();
            return categories;
        }

    }
}
