using System.Collections.Generic;
using MarketAppClasses.Entities;
using System;

namespace MarketAppClasses.Contract
{
    public class PurchaseOrderContract
    {
        public  int Code { get; set; }
        public Guid Id { get; set; }

        public  DateTime CreationDate { get; set; }
        public  string Title { get; set; }
        public virtual List<PurchaseOrderItemContract> PurchaseOrderItems { get; set; }
       
    }
}