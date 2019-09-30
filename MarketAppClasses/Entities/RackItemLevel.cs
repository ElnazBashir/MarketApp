using System;

namespace MarketAppClasses.Entities
{
    public class RackItemLevel:BaseEntity
    {
        public virtual double CurrentQuantity { get; set; }
        public virtual double InQuantity { get; set; }
        public virtual double OutQuantity { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual Item Item { get; set; }
       
    }
}