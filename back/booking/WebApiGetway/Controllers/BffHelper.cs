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




        //public static List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        //{
        //    var result = new List<Dictionary<string, object>>();

        //    if (element.ValueKind == JsonValueKind.Array)
        //    {
        //        foreach (var item in element.EnumerateArray())
        //        {
        //            if (item.ValueKind == JsonValueKind.Object)
        //                result.Add(ConvertObject(item));
        //        }
        //    }
        //    else if (element.ValueKind == JsonValueKind.Object)
        //    {
        //        result.Add(ConvertObject(element));
        //    }

        //    return result;
        //}

        //private static Dictionary<string, object> ConvertObject(JsonElement element)
        //{
        //    var dict = new Dictionary<string, object>();

        //    foreach (var prop in element.EnumerateObject())
        //    {
        //        dict[prop.Name] = ConvertValue(prop.Value);
        //    }

        //    return dict;
        //}

        //private static object ConvertValue(JsonElement element)
        //{
        //    return element.ValueKind switch
        //    {
        //        JsonValueKind.String => element.GetString(),
        //        JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.GetDecimal(),
        //        JsonValueKind.True => true,
        //        JsonValueKind.False => false,
        //        JsonValueKind.Object => ConvertObject(element),
        //        JsonValueKind.Array => element.EnumerateArray()
        //                                      .Select(ConvertValue)
        //                                      .ToList(),
        //        _ => null
        //    };
        //}





        public static List<Dictionary<string, object>> UpdateListWithTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
                   string idFieldName = "id",
                   string translationIdFieldName = "entityId")
        {
            foreach (var item in list)
            {
                if (!item.TryGetValue(idFieldName, out var idObj)) continue;
                if (!int.TryParse(idObj.ToString(), out int id)) continue;


                var translation = translations.FirstOrDefault(t =>
                    t.TryGetValue(translationIdFieldName, out var eid) &&
                    int.TryParse(eid.ToString(), out int eidInt) &&
                    eidInt == id
                );

                if (translation != null)
                {
                    if (item.ContainsKey("title"))
                        item["title"] = translation["title"];
                    if (item.ContainsKey("description"))
                        item["description"] = translation["description"];

                }
            }
            return list;
        }

    }

}
