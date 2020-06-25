using System;
using System.Text.Json;

namespace FuhoCommerce.Application.Common.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(object item)
        {
            if (item == null)
            {
                return null;
            }

            return System.Text.Json.JsonSerializer.Serialize(item, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public static T Deserialize<T>(string json)
        {
            if (String.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }

            return System.Text.Json.JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
