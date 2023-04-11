using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BookishMadness.DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BookStatus
    {
        WantToRead,
        Reading,
        Read
    }
}
