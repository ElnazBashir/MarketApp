using System;
using System.Collections.Generic;
using MarketAppClasses.Entities;

namespace MarketAppClasses
{
    public  abstract class Order:BaseEntity
    {
 
       // public virtual ICollection<OrderItem> OrderItems { get; set; }
       
        public virtual int Code { get; set; }

        public virtual DateTime CreationDate { get; set; }
        public virtual string Title { get; set; }
     

    }
}