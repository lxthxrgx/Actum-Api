using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Actum_Api.components.ILogger
{
    public static class JsonUTF8
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        public static string JsonOptions<T>(T data)
        {
            string json = JsonSerializer.Serialize(data, _jsonOptions);
            return json;
        }   
    }
}