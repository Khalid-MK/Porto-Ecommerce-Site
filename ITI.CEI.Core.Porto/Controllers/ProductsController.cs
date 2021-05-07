using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ITI.CEI.Core.Porto.Core;
using ITI.CEI.Core.Porto.Models;
using ITI.CEI.Core.Porto.Models.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ITI.CEI.Core.Porto.Controllers
{
    public class Products : Controller
    {
        private IUnitOfWork unitOfWork;

        private readonly UserManager<ApplicationUser> _userManager;

        public Products(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            _userManager = userManager;

        }

        public bool AddtoCart(int id , int noOfAddedProduct = 1)
        {
            if (unitOfWork.ProductManager.GetById(id) != null)
            {
                if (unitOfWork.OrderManager.GetAll().Where(x => x.Fk_User == _userManager.GetUserId(HttpContext.User)).ToList().Count == 0)
                {

                    Order order = new Order();
                    order.Fk_User = _userManager.GetUserId(HttpContext.User);
                    unitOfWork.OrderManager.Add(order);
                }

                ProductsOrder productsOrder = new ProductsOrder();
                productsOrder.ProductId = id;
                productsOrder.Quantity = noOfAddedProduct;
                productsOrder.OrderId = unitOfWork.OrderManager.GetAll().Where(x => x.Fk_User == _userManager.GetUserId(HttpContext.User)).FirstOrDefault().Id;
                if (unitOfWork.ProductOrderManager.GetAll().Where(j => j.ProductId == id && j.OrderId == productsOrder.OrderId).ToList().Count > 0)
                {
                    var y = unitOfWork.ProductOrderManager.GetAll().Where(j => j.ProductId == id && j.OrderId == productsOrder.OrderId).FirstOrDefault();
                    y.Quantity = noOfAddedProduct;
                    unitOfWork.ProductOrderManager.Update(y);
                }
                else
                {
                    unitOfWork.ProductOrderManager.Add(productsOrder);

                }
                return true;
            }
            return false;
        }


        public bool RemoveFromcart(int id)
        {
            if (unitOfWork.ProductManager.GetById(id) != null)
            {

                var productOrderIDFrmDb = unitOfWork.OrderManager.GetAll().Where(x => x.Fk_User == _userManager.GetUserId(HttpContext.User)).FirstOrDefault().Id;

                var y = unitOfWork.ProductOrderManager.GetAll().Where(j => j.ProductId == id && j.OrderId == productOrderIDFrmDb).FirstOrDefault();
                y.Quantity = --(unitOfWork.ProductOrderManager.GetAll().Where(c => c.ProductId == id).FirstOrDefault().Quantity);
                if (y.Quantity == 0)
                {
                    unitOfWork.ProductOrderManager.Delete(y);
                }
                else
                {
                    unitOfWork.ProductOrderManager.Update(y);

                }


                return true;
            }
            return false;
        }

        // GET: Products
        public async Task<IActionResult> Index(string filter, string sortExpression, int pageindex = 1)
        {

            var qry = unitOfWork.ProductManager.GetAll().AsNoTracking().Include(p => p.Category).Include(p => p.Images).Include(p => p.Owner).AsQueryable();// _context.Products.AsNoTracking().Include(p => p.Category).Include(p => p.ImgLst).AsQueryable();

                var CartProducts = unitOfWork.ProductOrderManager.GetAll().Include(j => j.Order).Include(p => p.product).Include(p => p.product.Images)
                    .Where(k => k.Order.Fk_User == _userManager.GetUserId(HttpContext.User));
            if (!string.IsNullOrWhiteSpace(filter))
            {
                    
                qry = qry.Where(p => p.Name.Contains(filter));
                var model = await PagingList.CreateAsync(qry as IOrderedQueryable<Product>, 9, pageindex);
                model.RouteValue = new RouteValueDictionary { { "filter", filter } };
                ProductViewModel productViewModel = new ProductViewModel
                {
                    Products = qry.ToList(),
                    Tags = unitOfWork.TagManager.GetAll().ToList(),
                    ProductsPaging = model,
                    Categories = unitOfWork.CategoryManager.GetAll().ToList(),
                    UserID = _userManager.GetUserId(HttpContext.User),
                  
                };
                return View(productViewModel);
            }
            else
            {

                switch (sortExpression)
                {
                    case "Price high to low":
                        qry = qry.OrderByDescending(s => s.UnitPrice * (1 - s.Discount / 100));
                        break;
                    case "Price low to high":
                        qry = qry.OrderBy(s => s.UnitPrice * (1 - s.Discount / 100));
                        break;
                    default:
                        qry = qry.OrderBy(s => s.Name);


                        break;
                }


                var model = await PagingList.CreateAsync(qry as IOrderedQueryable<Product>, 9, pageindex);

                model.RouteValue = new RouteValueDictionary { { "filter", filter } };

                ProductViewModel productViewModel = new ProductViewModel
                {
                    ProductsPaging = model,
                    Products = qry.Include(p=>p.Owner).ToList(),
                    Tags = unitOfWork.TagManager.GetAll().ToList(),
                    Categories = unitOfWork.CategoryManager.GetAll().ToList(),
                    UserID = _userManager.GetUserId(HttpContext.User),
                };
                return View(productViewModel);
            }
        }

        [AllowAnonymous]
        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var CartProducts = unitOfWork.ProductOrderManager.GetAll().Include(j => j.Order).Include(p => p.product).Include(p => p.product.Images)
                   .Where(k => k.Order.Fk_User == _userManager.GetUserId(HttpContext.User));

            Product product = unitOfWork.ProductManager.GetById(id);
            product.Images = unitOfWork.ImageManager.GetAll().Where(x => x.Fk_ProductId == id).ToList();
            product.ProductTags = unitOfWork.ProductTagsManager.GetAll().Where(x => x.ProductId == id).Include(c => c.Tag).ToList();
            product.Category = unitOfWork.CategoryManager.GetAll().Where(p => p.Id == product.Fk_Category).FirstOrDefault();
            product.ProductsOrders = CartProducts.ToList();
            if (product != null)
            {
                return View(product);

            }
            return BadRequest();

        }

        // GET: Products/Create
        [Authorize(Roles = "Shop_Owner,Admin")]
        public ActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = unitOfWork.CategoryManager.GetAll().ToList(),
                PaymentTypes = unitOfWork.PaymentTypeManager.GetAll().ToList()
            };

            return View(productViewModel);
        }

        // POST: Products/Create
        [Authorize(Roles = "Shop_Owner,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                // add category request 
                if (productViewModel.CategoryRequest.Title !=null)
                {
                    productViewModel.CategoryRequest.Fk_User = _userManager.GetUserId(HttpContext.User);

                    unitOfWork.CategoryRequestManager.Add(productViewModel.CategoryRequest);
                }


                if (productViewModel.Product != null)
                {

                    // add owner id to the product
                    productViewModel.Product.Fk_OwnerID = _userManager.GetUserId(HttpContext.User);

                    // add product before attach payment types to get id from data base
                    Product product = unitOfWork.ProductManager.Add(productViewModel.Product);

                    // add images
                    if (productViewModel.images != null)
                    {

                        for (int i = 0; i < productViewModel.images.Count(); i++)
                        {

                            if (productViewModel.images[i].Length > 0)
                            {
                                Image image = new Image();

                                using (var ms = new MemoryStream())
                                {
                                    productViewModel.images[i].CopyTo(ms);
                                    image.img = ms.ToArray();
                                }

                                image.Fk_ProductId = product.Id;

                                image.Title = product.Name + " Image";

                                unitOfWork.ImageManager.Add(image);
                            }

                        }
                    }

                    // check if tags != null 
                    if (productViewModel.Tags != null)
                    {

                        // Get all tags form database
                        List<Tag> tags_db = unitOfWork.TagManager.GetAll().ToList();

                        // clear tags in ProductViewModel from null
                        productViewModel.Tags.RemoveAll(t => t.Title == null);

                        // initial list<tag>
                        List<Tag> tags = productViewModel.Tags.ToList();

                        // container of duplicated value
                        List<Tag> duplicated_tags = new List<Tag>();

                        ///Avoid redundancy within the database 
                        ///due to duplication of data or contained within the database
                        foreach (Tag tag in productViewModel.Tags)
                        {
                            // similar tag from database
                            Tag tag_db = tags_db.Where(t => t.Title == tag.Title).FirstOrDefault();

                            if (tag_db != null)
                            {
                                tags.RemoveAll(t => t.Title == tag.Title);

                                if (!duplicated_tags.Contains(tag_db))
                                {
                                    duplicated_tags.Add(tag_db);
                                }
                            }
                        }

                        // attach old tags from database to product
                        AddTagsToProduct(product, duplicated_tags);

                        // add new tags to database
                        tags = unitOfWork.TagManager.AddList(tags);

                        // attach new tags to Product
                        AddTagsToProduct(product, tags);
                    }

                    // check if PaymentTypes != null
                    if (productViewModel.PaymentTypes != null)
                    {
                        // attach paymentTypes to Product
                        Product result = AddPaymentTypesToProduct(product, productViewModel.PaymentTypes);
                    }

                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Create");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize(Roles = "Shop_Owner,Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();


            productViewModel.Product = unitOfWork.ProductManager.GetAll().Where(pr => pr.Id == id)
                .Include(m => m.Images).Include(k => k.ProductPaymentTypes).Include(m => m.ProductTags).FirstOrDefault();

            productViewModel.PaymentTypes = unitOfWork.PaymentTypeManager.GetAll().ToList();

            productViewModel.Images = unitOfWork.ImageManager.GetAll().Where(im => im.Fk_ProductId == id).ToList();

            var PaymentTypes = unitOfWork.ProductPaymentManager.GetAll().Where(pa => pa.ProductId == id).Include(pay => pay.PaymentType).ToList();
            
            var x = unitOfWork.ProductTagsManager.GetAll().Where(tp => tp.ProductId == id).Include(r => r.Tag).ToList();
            
            List<Tag> v = new List<Tag>();
            foreach (var item in x)
            {
                v.Add(item.Tag);
            }
            
            productViewModel.Tags = v;
            
            productViewModel.Categories = unitOfWork.CategoryManager.GetAll().ToList();
            if (productViewModel == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = "No Department Found"
                };

                return View("Error", errorViewModel);
            }

            return View(productViewModel);
        }

        [Authorize(Roles = "Shop_Owner,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Product.Id)
            {
                return NotFound();
            }

            // add images
            if (productViewModel.images != null)
            {

                for (int i = 0; i < productViewModel.images.Count(); i++)
                {

                    if (productViewModel.images[i].Length > 0)
                    {
                        Image image = new Image();

                        using (var ms = new MemoryStream())
                        {
                            productViewModel.images[i].CopyTo(ms);
                            image.img = ms.ToArray();
                        }

                        image.Fk_ProductId = productViewModel.Product.Id;

                        image.Title = productViewModel.Product.Name + " Image";

                        unitOfWork.ImageManager.Add(image);
                    }

                }
            }
            else
            {
                // TODO: add defualt image to product
            }

            // remove old relations
            List<ProductTag> productTagsRemoveRel = unitOfWork.ProductTagsManager.GetAll().Where(t => t.ProductId == productViewModel.Product.Id).ToList();

            foreach (ProductTag productTag in productTagsRemoveRel)
            {
                unitOfWork.ProductTagsManager.Delete(productTag);
            }

            // check if tags != null 
            if (productViewModel.Tags != null)
            {

                // Get all tags form database
                List<Tag> tags_db = unitOfWork.TagManager.GetAll().ToList();

                // clear tags in ProductViewModel from null
                productViewModel.Tags.RemoveAll(t => t.Title == null);

                // initial list<tag>
                List<Tag> tags = productViewModel.Tags.ToList();

                // container of duplicated value
                List<Tag> duplicated_tags = new List<Tag>();

                ///Avoid redundancy within the database 
                ///due to duplication of data or contained within the database
                foreach (Tag tag in productViewModel.Tags)
                {
                    // similar tag from database
                    Tag tag_db = tags_db.Where(t => t.Title == tag.Title).FirstOrDefault();

                    if (tag_db != null)
                    {
                        tags.RemoveAll(t => t.Title == tag.Title);

                        if (!duplicated_tags.Contains(tag_db))
                        {
                            duplicated_tags.Add(tag_db);
                        }
                    }
                }

                // attach old tags from database to product
                AddTagsToProduct(productViewModel.Product, duplicated_tags);

                // add new tags to database
                tags = unitOfWork.TagManager.AddList(tags);

                // attach new tags to Product
                AddTagsToProduct(productViewModel.Product, tags);
            }

            // check if PaymentTypes != null
            if (productViewModel.PaymentTypes != null)
            {
                List<ProductPaymentType> productPaymentTypes = unitOfWork.ProductPaymentManager.GetAll().Where(p => p.ProductId == productViewModel.Product.Id).ToList();

                foreach (var productPaymentType in productPaymentTypes)
                {
                    unitOfWork.ProductPaymentManager.Delete(productPaymentType);
                }

                Product result = AddPaymentTypesToProduct(productViewModel.Product, productViewModel.PaymentTypes);

            }

            //update product 
            unitOfWork.ProductManager.Update(productViewModel.Product);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Shop_Owner,Admin")]
        public bool Delete(int id)
        {
            if (unitOfWork.ProductManager.GetById(id) != null)
            {
                unitOfWork.ProductManager.Delete(unitOfWork.ProductManager.GetById(id));
                return true;
            }
            return false;

        }

        public async Task<IActionResult> GetProductsByCategories(string filter, string category, int pageindex = 1)
        {
            var qry = unitOfWork.ProductManager.GetAll().Where(x => x.Category.Name == category).Include(p => p.Images).AsNoTracking().OrderBy(s => s.Name);
            var model = await PagingList.CreateAsync(qry as IOrderedQueryable<Product>, 9, pageindex);
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductsPaging = model,
                Products = qry.ToList(),
                Tags = unitOfWork.TagManager.GetAll().ToList(),
                UserID = _userManager.GetUserId(HttpContext.User),
                Categories = unitOfWork.CategoryManager.GetAll().ToList()
            };
            // unitOfWork.ProductManager.GetAll().Where(x => x.Category.Name == category);
            return View(nameof(Index), productViewModel);
        }

        public async Task<IActionResult> GetProductsByTag(string filter, string Title, int pageindex = 1)
        {
            var qry = from EachProduct in unitOfWork.ProductManager.GetAll()
                      from EachTag in EachProduct.ProductTags
                      where EachTag.Tag.Title == Title
                      select EachProduct;

           var model = await PagingList.CreateAsync(qry as IOrderedQueryable<Product>, 9, pageindex);
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
          
            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductsPaging = model,
                Tags = unitOfWork.TagManager.GetAll().ToList(),
                Products = qry.Include(p => p.Images).ToList(),
                UserID = _userManager.GetUserId(HttpContext.User),
                Categories = unitOfWork.CategoryManager.GetAll().ToList()
            };
            return View(nameof(Index), productViewModel);
        }

        #region Methods

        // Attach true payment type to the product
        private Product AddPaymentTypesToProduct(Product product, List<PaymentType> paymentTypes)
        {
            foreach (PaymentType item in paymentTypes)
            {
                if (item.checkBoxAnswer)
                {
                    ProductPaymentType productPayment = new ProductPaymentType()
                    {
                        ProductId = product.Id,
                        PaymentTypeId = item.Id,
                    };

                    unitOfWork.ProductPaymentManager.Add(productPayment);
                }
            }

            return product;
        }

        // Attach tags to product
        public Product AddTagsToProduct(Product product, List<Tag> tags)
        {
            foreach (Tag tag in tags)
            {
                ProductTag productTag = new ProductTag()
                {
                    ProductId = product.Id,
                    TagId = tag.Id,
                };
                unitOfWork.ProductTagsManager.Add(productTag);
            }
            return product;
        }

        public Product AddTagsToProduct(Product product, Tag tag)
        {
            ProductTag productTag = new ProductTag()
            {
                ProductId = product.Id,
                TagId = tag.Id,
            };
            unitOfWork.ProductTagsManager.Add(productTag);

            return product;
        }

        #endregion
    }
}