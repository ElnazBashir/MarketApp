using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;


namespace MArketApp
{
    public class PurchaseOrderMapping : IAutoMappingOverride<PurchaseOrder>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<PurchaseOrder> mapping)
        {
             mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.Code);
            mapping.Map(x => x.CreationDate);
            mapping.Map(x => x.Title);
            mapping.HasMany(x => x.PurchaseOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}