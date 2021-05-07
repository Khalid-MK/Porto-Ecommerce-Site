using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class PaymentType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [NotMapped]
        public bool checkBoxAnswer { get; set; }

        public virtual List<ProductPaymentType> ProductPaymentTypes { get; set; }
    }
}
