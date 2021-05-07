using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class ProductPaymentType
    {
        public int ProductId { get; set; }

        public int PaymentTypeId { get; set; }

        public virtual Product product { get; set; }

        public virtual PaymentType PaymentType { get; set; }
    }
}
