using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace DATN.PARKING.API
{
    public static class JsonUtils<T> where T : class
    {
        public static string ToJson(object obj) => JsonConvert.SerializeObject(obj);

        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
        public static string ToJson(List<T> lst) => JsonConvert.SerializeObject(lst, Formatting.None);
        /// <summary>
        /// Deserial Json to Obj
        /// </summary>
        public static T JsonToObj(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);


        public static T ToObj<T>(string obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };
            return JsonConvert.DeserializeObject<T>(obj);
        }

        /// <summary>
        /// Deserial Json to List Obj
        /// </summary>
        public static List<T> JsonToListObj(string json) => JsonConvert.DeserializeObject<List<T>>(json);

        /// <summary>
        /// Serial List Obj to Json
        /// </summary>
        public static string ListObjToJson(List<T> lst) => JsonConvert.SerializeObject(lst, Converter.ToJsonIgnoreNullProp);

        /// <summary>
        /// Serial Obj to Json
        /// </summary>
        public static string ObjToJson(T obj) => JsonConvert.SerializeObject(obj, Converter.ToJsonIgnoreNullProp);

        /// <summary>
        /// 
        /// </summary>
        public class Converter
        {
            /// <summary>
            /// 
            /// </summary>
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };

            /// <summary>
            /// Json serial setting: None formatting, Ignore null prop
            /// </summary>
            public static readonly JsonSerializerSettings ToJsonIgnoreNullProp = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
            };
        }
    }
}
