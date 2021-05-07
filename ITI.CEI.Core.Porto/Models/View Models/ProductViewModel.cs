using Microsoft.AspNetCore.Http;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models.View_Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public PagingList<Product> ProductsPaging { get; set; }
        
        public List<Category> Categories { get; set; }

        public List<PaymentType> PaymentTypes { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Image> Images { get; set; }
        public List<ProductsOrder> productorders { get; set; }
        public List<IFormFile> images { get; set; }

        public string UserID { get; set; }

        public CategoryRequest CategoryRequest { get; set; }


    }
}
