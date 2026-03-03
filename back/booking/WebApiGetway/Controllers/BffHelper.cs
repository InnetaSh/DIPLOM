using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApiGetway.Controllers
{
    public class BffHelper
    {
        //public static List<Dictionary<string, object>> ConvertActionResultToDict(OkObjectResult objResult)
        //{
        //    if (objResult?.Value is JsonElement element)
        //        return ConvertElementToDict(element);
        //    return null;
        //}

        //public static List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        //{
        //    var dictList = new List<Dictionary<string, object>>();
        //    if (element.ValueKind == JsonValueKind.Array)
        //        dictList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(element.GetRawText());
        //    else if (element.ValueKind == JsonValueKind.Object)
        //    {
        //        var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
        //        dictList.Add(obj);
        //    }
        //    else return null;

        //    foreach (var dl in dictList)
        //        foreach (var key in dl.Keys)
        //            if (dl[key] is JsonElement el
        //                && (el.ValueKind == JsonValueKind.Array || el.ValueKind == JsonValueKind.Object))
        //                dl[key] = ConvertElementToDict(el);
        //    return dictList;
        //}

        public static List<Dictionary<string, object>> ConvertActionResultToDict(OkObjectResult objResult)
        {
            if (objResult?.Value == null)
                return new List<Dictionary<string, object>>();

            if (objResult.Value is List<Dictionary<string, object>> list)
                return list;

            if (objResult.Value is JsonElement element)
                return ConvertElementToDict(element);

            return new List<Dictionary<string, object>>();
        }

        public static List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        {
            var dictList = new List<Dictionary<string, object>>();

            if (element.ValueKind == JsonValueKind.Array)
                dictList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(element.GetRawText()) ?? new List<Dictionary<string, object>>();
            else if (element.ValueKind == JsonValueKind.Object)
            {
                var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
                if (obj != null) dictList.Add(obj);
            }
            else if(element.ValueKind == JsonValueKind.Number)
            {
                if (Double.TryParse(element.GetRawText(), out var num))
                {
                    var d = new Dictionary<string, object>();
                    d["number"] = num;
                    dictList.Add(d);
                    return dictList;
                }
            }
            else
                return new List<Dictionary<string, object>>();

            for (int i = 0; i < dictList.Count; i++)
            {
                var dl = dictList[i];
                foreach (var key in dl.Keys.ToList())
                {
                    if (dl[key] is JsonElement el &&
                        (el.ValueKind == JsonValueKind.Array || el.ValueKind == JsonValueKind.Object))
                    {
                        dl[key] = ConvertElementToDict(el);
                    }
                }
            }

            return dictList;
        }





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
                    CopyIfExists(item, translation, "title");
                    CopyIfExists(item, translation, "description");
                    CopyIfExists(item, translation, "history");
                    CopyIfExists(item, translation, "titleInfo");
                    CopyIfExists(item, translation, "street");
                }
            }
            return list;
        }


        public static List<Dictionary<string, object>> UpdateParamListWithTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
  string idFieldName = "paramItemId",
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
                    CopyIfExists(item, translation, "title");
                }
            }
            return list;
        }



        public static List<Dictionary<string, object>> UpdateAttractionsListWithTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
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
                    CopyIfExists(item, translation, "title");
                    CopyIfExists(item, translation, "description");
                    CopyIfExists(item, translation, "address");
                }
            }
            return list;
        }

        public static List<Dictionary<string, object>> UpdateListWithCityTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
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
                    CopyIfExists(item, translation, "title");
                    CopyIfExists(item, translation, "description");
                    CopyIfExists(item, translation, "titleInfo");
                    CopyIfExists(item, translation, "street");
                }
            }
            return list;
        }

        public static void UpdateCityTitlesInOffers(
            List<Dictionary<string, object>> statisticOfferDictList,
            List<Dictionary<string, object>> translations)
        {
           
            var translationLookup = translations
                .Where(t => t.ContainsKey("entityId") && t.ContainsKey("title"))
                .ToDictionary(
                    t => int.Parse(t["entityId"].ToString()),
                    t => t["title"]
                );

            foreach (var offer in statisticOfferDictList)
            {
                if (!offer.TryGetValue("rentObj", out var rentObjRaw))
                    continue;

                var rentList = rentObjRaw as List<Dictionary<string, object>>;
                if (rentList == null || rentList.Count == 0)
                    continue;

                foreach (var rentObj in rentList)
                {
                    if (!rentObj.TryGetValue("cityId", out var cityIdRaw))
                        continue;

                    if (!int.TryParse(cityIdRaw?.ToString(), out int cityId))
                        continue;

                    if (translationLookup.TryGetValue(cityId, out var title))
                    {
                        rentObj["cityTitle"] = title;
                    }
                }
            }
        }




        public static List<Dictionary<string, object>> UpdateOfferListWithRating(List<Dictionary<string, object>> list, List<Dictionary<string, object>> ratings,
            string idFieldName = "id",
            string ratingIdFieldName = "OfferId")
        {
            foreach (var item in list)
            {
                var itemKey = item.Keys.FirstOrDefault(k => k.Equals(idFieldName, StringComparison.OrdinalIgnoreCase));
                if (itemKey == null) continue;

                if (!int.TryParse(item[itemKey]?.ToString(), out int id)) continue;

                var rating = ratings.FirstOrDefault(r =>
                {
                    var ratingKey = r.Keys.FirstOrDefault(k => k.Equals(ratingIdFieldName, StringComparison.OrdinalIgnoreCase));
                    return ratingKey != null && int.TryParse(r[ratingKey]?.ToString(), out int rid) && rid == id;
                });

                if (rating == null) continue;

                CopyIfExists(item, rating, "Staff");
                CopyIfExists(item, rating, "Facilities");
                CopyIfExists(item, rating, "Cleanliness");
                CopyIfExists(item, rating, "Comfort");
                CopyIfExists(item, rating, "ValueForMoney");
                CopyIfExists(item, rating, "Location");
                CopyIfExists(item, rating, "OverallRating");
            }
            return list;
        }
        private static void CopyIfExists(
            Dictionary<string, object> target,
            Dictionary<string, object> source,
            string key)
        {
            var targetKey = target.Keys
               .FirstOrDefault(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (targetKey == null) return;

            var sourceKey = source.Keys
                .FirstOrDefault(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (sourceKey == null) return;

            target[targetKey] = source[sourceKey];
        }





    }

}
