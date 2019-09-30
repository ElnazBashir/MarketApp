using System;


namespace MarketAppClasses.Contract
{
    public class RackItemLevelContract
    {
        public  double CurrentQuantity { get; set; }
        public  double InQuantity { get; set; }
        public  double OutQuantity { get; set; }
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
    }
}