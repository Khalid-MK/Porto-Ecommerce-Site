using ITI.CEI.Core.Porto.Data;
using ITI.CEI.Core.Porto.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private ProductManager productManager;
        public ProductManager ProductManager
        {
            get
            {
                if (productManager == null)
                {
                    productManager = new ProductManager(context);
                }
                return productManager;
            }
        }

        private CategoryManager categoryManager;
        public CategoryManager CategoryManager
        {
            get
            {
                if (categoryManager == null)
                {
                    categoryManager = new CategoryManager(context);
                }
                return categoryManager;
            }
        }

        private TagManager tagManager;
        public TagManager TagManager
        {
            get
            {
                if (tagManager == null)
                {
                    tagManager = new TagManager(context);
                }
                return tagManager;
            }
        }

        private PaymentTypeManager paymentTypeManager;
        public PaymentTypeManager PaymentTypeManager
        {
            get
            {
                if (paymentTypeManager == null)
                {
                    paymentTypeManager = new PaymentTypeManager(context);
                }
                return paymentTypeManager;
            }
        }

        private OrderManager orderManager;
        public OrderManager OrderManager 
        {
            get
            {
                if (orderManager == null)
                {
                    orderManager = new OrderManager(context);
                }
                return orderManager;
            }
        }

        private CategoryRequestManager categoryRequestManager;
        public CategoryRequestManager CategoryRequestManager
        {
            get
            {
                if (categoryRequestManager == null)
                {
                    categoryRequestManager = new CategoryRequestManager(context);
                }
                return categoryRequestManager;
            }
        }

        private ImageManager imageManager;
        public ImageManager ImageManager
        {
            get
            {
                if (imageManager == null)
                {
                    imageManager = new ImageManager(context);
                }
                return imageManager;
            }
        }

        private ProductPaymentManager productPaymentManager;
        public ProductPaymentManager ProductPaymentManager 
        {
            get
            {
                if (productPaymentManager == null)
                {
                    productPaymentManager = new ProductPaymentManager(context);
                }
                return productPaymentManager;
            }
        }

        private ProductTagsManager productTagsManager;
        public ProductTagsManager ProductTagsManager
        {
            get
            {
                if (productTagsManager == null)
                {
                    productTagsManager = new ProductTagsManager(context);
                }
                return productTagsManager;
            }
        }
        private ProductOrderManager productOrderManager;
        public ProductOrderManager ProductOrderManager
        {
            get
            {
                if (productOrderManager == null)
                {
                    productOrderManager = new ProductOrderManager(context);
                }
                return productOrderManager;
            }
        }
    }
}
