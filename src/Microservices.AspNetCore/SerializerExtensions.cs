using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Microservices.AspNetCore
{
    public static class SerializerExtensions
    {
        public static string SerializeObject<T>(this JsonSerializer serializer, T jsonObject) where T : class
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new JsonTextWriter(new StreamWriter(memoryStream)))
            {
                serializer.Serialize(writer, jsonObject);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T DeserializeObject<T>(this JsonSerializer serializer, string jsonContent) where T : class
        {
            using (var reader = new JsonTextReader(new StringReader(jsonContent)))
                return serializer.Deserialize<T>(reader);
        }
    }
}