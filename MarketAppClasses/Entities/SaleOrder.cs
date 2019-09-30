using System.Collections.Generic;

namespace MarketAppClasses.Entities
{
    public class SaleOrder : Order
    {
        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }
        public SaleOrder()
        {

            SaleOrderItems = new List<SaleOrderItem>();

        }
    }
}