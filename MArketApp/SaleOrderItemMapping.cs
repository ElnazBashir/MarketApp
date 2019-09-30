using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;

namespace MArketApp
{
    public class SaleOrderItemMapping:IAutoMappingOverride<SaleOrderItem>
    {
        public void Override(AutoMapping<SaleOrderItem> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.Quantity);
            mapping.Map(x => x.NetPrice);
            mapping.Map(x => x.TotalPrice);
            mapping.Map(x => x.Quantity);
            mapping.Map(x => x.UnitPrice);
            mapping.References(x => x.Item).Unique().Not.Nullable();
            mapping.References(x => x.Rack).Unique().Not.Nullable();
        }
    }
}