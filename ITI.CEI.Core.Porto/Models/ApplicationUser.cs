using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Order> Orders { get; set; }

        
    }
}
