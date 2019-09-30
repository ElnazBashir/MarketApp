using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;


namespace MArketApp
{
    public class SaleOrderMapping:IAutoMappingOverride<SaleOrder>
    {
        public void Override(AutoMapping<SaleOrder> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.Code);
            mapping.Map(x => x.CreationDate);
            mapping.Map(x => x.Title);
            mapping.HasMany(x => x.SaleOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}