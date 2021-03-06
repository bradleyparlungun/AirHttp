namespace AirHttp.Configuration
{
    public interface IAirContentProcessor
    {
        string ContentType { get; }

        T DeserializeObject<T>(string serializedObject);

        string SerializeObject<T>(T pocoObject);
    }
}
