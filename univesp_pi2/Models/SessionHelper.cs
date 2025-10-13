using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace univesp_pi2.Helpers
{
    public static class SessionHelper
    {
        // Método para "guardar" um objeto na sessão
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Método para "pegar" um objeto da sessão
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}