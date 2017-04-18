using Newtonsoft.Json;

namespace System
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj, Formatting formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject(obj, formatting);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
