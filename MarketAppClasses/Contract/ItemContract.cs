using System;

namespace MarketAppClasses.Contract
{
    public class ItemContract
    {
        public virtual int Code { get; set; }

        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
        public Guid Id { get; set; }
    }
}