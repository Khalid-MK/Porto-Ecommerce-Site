using ITI.CEI.Core.Porto.Data;
using ITI.CEI.Core.Porto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core.Managers
{
    public class CategoryRequestManager : Repository<CategoryRequest, ApplicationDbContext>
    {
        public CategoryRequestManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
