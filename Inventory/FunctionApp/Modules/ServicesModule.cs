using Autofac;

namespace Inventory
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryHelper>().As<IInventoryHelper>();
            builder.RegisterType<AzureTableOperation>().As<ITable>();
        }
    }
}