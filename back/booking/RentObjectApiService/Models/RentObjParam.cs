using Globals.Models;
using RentObjectApiService.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RentObjectApiService.Models
{
    public class RentObjParam : EntityBase
    {
        public string Title { get; set; }

        public string ValueJson { get; set; }

        public ParamType Type { get; set; }

        [NotMapped]
        public object? Value
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ValueJson))
                    return null;

                try
                {
                    return Type switch
                    {
                        ParamType.Int => JsonSerializer.Deserialize<int>(ValueJson),
                        ParamType.Bool => JsonSerializer.Deserialize<bool>(ValueJson),
                        ParamType.Double => JsonSerializer.Deserialize<double>(ValueJson),
                        ParamType.Decimal => JsonSerializer.Deserialize<decimal>(ValueJson),
                        ParamType.DateTime => JsonSerializer.Deserialize<DateTime>(ValueJson),
                        ParamType.Json => JsonSerializer.Deserialize<object>(ValueJson),
                        _ => JsonSerializer.Deserialize<string>(ValueJson)
                    };
                }
                catch
                {
                    return ValueJson;
                }
            }

            set
            {
                if (value == null)
                {
                    ValueJson = null;
                    Type = ParamType.String;
                    return;
                }

                try
                {
                    ValueJson = JsonSerializer.Serialize(value);

                    Type = value switch
                    {
                        int => ParamType.Int,
                        bool => ParamType.Bool,
                        double => ParamType.Double,
                        decimal => ParamType.Decimal,
                        DateTime => ParamType.DateTime,
                        _ => ParamType.String
                    };
                }
                catch
                {
                    ValueJson = value.ToString();
                    Type = ParamType.String;
                }
            }
        }
    }


    //public class RentObjParam<T> : EntityBase 
    //{ 
    //    public int Id { get; set; } 
    //    public string Name { get; set; }
    //    public T Value { get; set; } 
    //}

    public class Param<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }

}
