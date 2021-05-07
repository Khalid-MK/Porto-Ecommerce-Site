using ITI.CEI.Core.Porto.Data;
using ITI.CEI.Core.Porto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core.Managers
{
    public class ProductOrderManager : Repository<ProductsOrder, ApplicationDbContext>
    {
        public ProductOrderManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
