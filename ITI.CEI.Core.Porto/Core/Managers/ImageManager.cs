using ITI.CEI.Core.Porto.Data;
using ITI.CEI.Core.Porto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core.Managers
{
    public class ImageManager : Repository<Image, ApplicationDbContext>
    {
        public ImageManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
