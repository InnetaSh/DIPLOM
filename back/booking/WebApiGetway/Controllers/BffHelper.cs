using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApiGetway.Controllers
{
    public class BffHelper
    {
        public static List<Dictionary<string, object>> ConvertActionResultToDict(OkObjectResult objResult)
        {
            if (objResult?.Value is JsonElement element)
                return ConvertElementToDict(element);
            return null;
        }

        public static List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        {
            var dictList = new List<Dictionary<string, object>>();
            if (element.ValueKind == JsonValueKind.Array)
                dictList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(element.GetRawText());
            else if (element.ValueKind == JsonValueKind.Object)
            {
                var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
                dictList.Add(obj);
            }
            else return null;

            foreach (var dl in dictList)
                foreach (var key in dl.Keys)
                    if (dl[key] is JsonElement el
                        && (el.ValueKind == JsonValueKind.Array || el.ValueKind == JsonValueKind.Object))
                        dl[key] = ConvertElementToDict(el);
            return dictList;
        }
    }
}
