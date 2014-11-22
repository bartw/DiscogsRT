using System;

namespace BeeWee.DiscogsRT
{
    public static class Extensions
    {
        public static string UrlEncode(this string stringToEscape)
        {
            return Uri.EscapeDataString(stringToEscape)
                .Replace(" ", "+")
                .Replace("!", "%21")
                .Replace("*", "%2A")
                .Replace("'", "%27")
                .Replace("(", "%28")
                .Replace(")", "%29");
        }
    }
}
