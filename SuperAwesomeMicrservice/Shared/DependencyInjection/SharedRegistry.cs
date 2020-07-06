using StructureMap;

namespace Shared.DependencyInjection
{
    public class SharedRegistry : Registry 
    {
        public SharedRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
