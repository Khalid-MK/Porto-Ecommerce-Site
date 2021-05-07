using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public List<ProductTag> ProductTags { get; set; }
    }
}
