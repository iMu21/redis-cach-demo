namespace RedisDemoProject.Interfaces
{
    public interface IRedisCacheService
    {
        Task<bool> Set(string key, string value);
        Task<string?> Get(string key);
    }
}
