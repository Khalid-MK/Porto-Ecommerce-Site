using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Price")]
        public int UnitPrice { get; set; }

        [Range(0,100)]
        [Display(Name = "Discount %")]
        public double? Discount { get; set; }

        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int Fk_Category { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Owner")]
        [Display(Name = "Product Owner")]
        public string Fk_OwnerID { get; set; }

        public ApplicationUser Owner { get; set; }

        public List<ProductTag> ProductTags { get; set; }

        public virtual List<ProductPaymentType> ProductPaymentTypes { get; set; }

        [NotMapped]
        public List<ProductsOrder> ProductsOrders { get; set; }

        public  List<Image> Images { get; set; }

    
      
  


        [NotMapped]
        [Display(Name = "Price Low To High")]
        public string PriceLowToHigh { get; set; }
        [NotMapped]
        [Display(Name = "Price High To Low")]
        public string PriceHighToLow { get; set; }
    }
}
