using Newtonsoft.Json;
using SteamHttp.Configuration;
using SteamHttp.Protocols;

namespace SteamHttp.NewtonsoftJson.Configuration
{
    public class NewtonsoftJsonSteamHttpContentConfiguration : ISteamHttpContentConfiguration
    {
        public string ContentType => ContentTypes.Json;

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
