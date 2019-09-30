using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;


namespace MArketApp
{
    public class ItemMapping:IAutoMappingOverride<Item>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<Item> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.Code);
            mapping.Map(x => x.Name);
            mapping.Map(x => x.Unit);
        }
    }
}