using dpLibrary05.Infrastructure.ServiceLocator;

namespace Dataplace.Imersao.Core.Infra
{
    public static class BootStrapper
    {

        public static Container Container;
        public static void Bootstrap(Container container)
        {
            Container = container;
        }

    }
}
