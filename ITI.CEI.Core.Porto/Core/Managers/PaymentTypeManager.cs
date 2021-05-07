using ITI.CEI.Core.Porto.Data;
using ITI.CEI.Core.Porto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core.Managers
{
    public class PaymentTypeManager : Repository<PaymentType, ApplicationDbContext>
    {
        public PaymentTypeManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
