using System;
using System.Collections.Generic;

namespace MarketAppClasses.Contract
{
    public class SaleOrderContract
    {
        public  int Code { get; set; }
        public Guid Id { get; set; }

        public  DateTime CreationDate { get; set; }
        public  string Title { get; set; }
        public virtual List<SaleOrderItemContract> SaleOrderItems { get; set; }
    }
}