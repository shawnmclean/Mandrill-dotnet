using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Mandrill
{
    public class JSON
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Converters = new[] { new IsoDateTimeConverter() },
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
        }; 

        public static dynamic Parse(string json)
        {
            return JsonConvert.DeserializeObject<dynamic>(json, settings);
        }

        public static T Parse<T>(string json) where T : new()
        {
            if (json == null)
            {
                return new T();
            }
            else
            {
                try
                {                    
                    return JsonConvert.DeserializeObject<T>(json, settings);
                }
                catch (JsonReaderException)
                {
                    Trace.TraceWarning("Unable to parse JSON - {0}", json);
                    return new T();
                }
            }
        }

        public static string Serialize(dynamic dyn)
        {
            return JsonConvert.SerializeObject(dyn, settings);
        }
    }
}
