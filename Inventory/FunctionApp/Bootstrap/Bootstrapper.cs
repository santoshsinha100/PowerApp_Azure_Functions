using Autofac;
using AutofacOnFunctions.Services.Ioc;

namespace Inventory
{
    public class Bootstrapper : IBootstrapper
    {
        public Module[] CreateModules()
        {
            //// to return new service module
            return new Module[]
            {
                new ServicesModule()
            };
        }
    }
}