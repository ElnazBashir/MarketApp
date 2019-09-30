using System;

namespace MarketAppClasses
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();

        }
    }
}