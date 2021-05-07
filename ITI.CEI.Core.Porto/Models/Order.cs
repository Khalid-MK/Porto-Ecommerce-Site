using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateTime { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        public string Fk_User { get; set; }

        public ApplicationUser User { get; set; }

        public List<ProductsOrder> ProductsOrders { get; set; }


    }
}
