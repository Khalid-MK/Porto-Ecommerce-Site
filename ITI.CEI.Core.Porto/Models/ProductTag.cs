using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class ProductTag
    {
        public int ProductId { get; set; }

        public int TagId { get; set; }

        public Product product { get; set; }

        public Tag Tag { get; set; }
    }
}
