using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;


namespace MArketApp
{
    public class RackItemLevelMapping:IAutoMappingOverride<RackItemLevel>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<RackItemLevel> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.CurrentQuantity);
            mapping.Map(x => x.InQuantity);
            mapping.Map(x => x.OutQuantity);
            mapping.References(x => x.Rack).Unique().Not.Nullable();
            mapping.References(x => x.Item).Unique().Not.Nullable();
        }
    }
}