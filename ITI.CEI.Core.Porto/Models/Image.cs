using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class Image
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Add Image")]
        
        public byte[] img { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Product")]
        public int Fk_ProductId { get; set; }

        public  Product Product { get; set; }

    }
}
