using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models.View_Models
{
    public class AdminViewModel
    {

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public Category Category { get; set; }

        public List<PaymentType> PaymentTypes { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public IdentityRole Role { get; set; }

        public List<CategoryRequest> CategoryRequests { get; set; }
    }
}
