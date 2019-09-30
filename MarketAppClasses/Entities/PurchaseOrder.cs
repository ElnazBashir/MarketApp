using System.Collections.Generic;

namespace MarketAppClasses.Entities
{
    public class PurchaseOrder : Order
    {
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public PurchaseOrder()
        {

            PurchaseOrderItems = new List<PurchaseOrderItem>();

        }

    }
}