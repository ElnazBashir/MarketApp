using System;
using FluentNHibernate.Automapping;
using MarketAppClasses;

namespace MArketApp
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            //return type.Namespace == "MarketAppClasses.Entities";
            //return  type.Namespace.EndsWith("Entities");
            return typeof(BaseEntity).IsAssignableFrom(type)&& !type.IsAbstract;

        }
    }
}