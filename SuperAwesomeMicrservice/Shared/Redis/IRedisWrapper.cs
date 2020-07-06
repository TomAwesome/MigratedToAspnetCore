using System.Threading.Tasks;

namespace Shared.Redis
{
    public interface IRedisWrapper
    {
        Task SaveAsync(string key, string body);
        Task<string> GetAsync(string key);
    }
}