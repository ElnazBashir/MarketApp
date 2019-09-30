using System;
namespace MarketAppClasses.Contract
{
    public class RackContract
    {
        public Guid Id { get; set; }
        public  int Code { get; set; }

        public  double Limit { get; set; }
        public  string Location { get; set; }
        public  string Name { get; set; }
        public Guid rackId { get; set; }
    }
}