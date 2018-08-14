
namespace SteamHttp.Configuration
{
    public interface ISteamHttpConfiguration
    {
        string ContentType { get; }

        T DeserializeObject<T>(string serializedObject);

        string SerializeObject<T>(T pocoObject);
    }
}
