using AwesomeLogger;
using StructureMap;

namespace Shared.DependencyInjection
{
    public class SharedRegistry : Registry 
    {
        public SharedRegistry()
        {
            Scan(scan => {
                scan.AssemblyContainingType<SharedRegistry>();
                scan.WithDefaultConventions();
            });
            For<ILogger>().Use(ctx => new Logger()).Singleton();
        }
    }
}
