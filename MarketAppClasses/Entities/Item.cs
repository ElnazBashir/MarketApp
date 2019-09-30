using System;

namespace MarketAppClasses.Entities
{
    public class Item:BaseEntity
    {

        public virtual int Code { get; set; }
        
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
       
    }
}