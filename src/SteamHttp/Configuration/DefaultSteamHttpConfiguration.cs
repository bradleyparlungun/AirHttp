
using Newtonsoft.Json;

namespace SteamHttp.Configuration
{
    public class DefaultSteamHttpConfiguration : ISteamHttpConfiguration
    {
        public string ContentType => "application/json";

        public T DeserializeObject<T>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public string SerializeObject<T>(T pocoObject)
        {
            return JsonConvert.SerializeObject(pocoObject);
        }
    }
}
