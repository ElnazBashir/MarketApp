using FluentNHibernate.Automapping.Alterations;
using MarketAppClasses.Entities;

namespace MArketApp
{
    public class RackMapping:IAutoMappingOverride<Rack>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<Rack> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.Code);
            mapping.Map(x => x.Limit);
            mapping.Map(x => x.Location);
            mapping.Map(x => x.Name);
            mapping.References(x => x.rack).Not.Nullable();

        }
    }
}