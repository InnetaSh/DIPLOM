using Globals.Controllers;
using System.Text.Json.Serialization;

namespace OfferContracts.RentObj.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ParamValueType
    {
        Boolean = 1,
        Integer = 2,
        String = 3,
        Double = 4,
        DateTime = 5,
        Int = 6
    }
}
