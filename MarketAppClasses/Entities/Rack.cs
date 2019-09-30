using System;

namespace MarketAppClasses.Entities
{
    public class Rack:BaseEntity
    {
        public virtual int Code { get; set; }
      
        public virtual double Limit { get; set; }
        public virtual string Location { get; set; }
        public virtual string Name { get; set; }
        public virtual Rack rack { get; set; }
        //add noting 
    }
}