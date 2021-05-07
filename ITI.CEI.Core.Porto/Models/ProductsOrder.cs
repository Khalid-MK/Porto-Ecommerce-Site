using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class ProductsOrder
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public Product product { get; set; }

        public Order Order { get; set; }


    }
}
