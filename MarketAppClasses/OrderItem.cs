using System;
using MarketAppClasses.Entities;

namespace MarketAppClasses
{
    public abstract class OrderItem:BaseEntity
    {
      
        public virtual decimal NetPrice { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }

 
    }
}