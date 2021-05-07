using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class CategoryRequest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        public string Fk_User { get; set; }

        public ApplicationUser User { get; set; }
    }
}
