using ITI.CEI.Core.Porto.Models;
using ITI.CEI.Core.Porto.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core
{
    public interface IUnitOfWork
    {
        ProductManager ProductManager { get; }

        CategoryManager CategoryManager { get; }

        OrderManager OrderManager { get; }

        PaymentTypeManager PaymentTypeManager { get; }

        TagManager TagManager { get; }

        CategoryRequestManager CategoryRequestManager { get; }

        ImageManager ImageManager { get; }

        ProductPaymentManager ProductPaymentManager { get; }
        ProductOrderManager ProductOrderManager { get; }

        ProductTagsManager ProductTagsManager { get;  }
    }
}
