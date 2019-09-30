using System;

namespace MarketAppClasses.Contract
{
    public class SaleOrderItemContract
    {

        public virtual decimal NetPrice { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
        public Guid Id { get; set; }
    }
}