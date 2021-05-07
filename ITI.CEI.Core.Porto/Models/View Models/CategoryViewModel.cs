using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models.View_Models
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Tag> Tags { get; set; }

        public string UserID { get; set; }
    }
}
