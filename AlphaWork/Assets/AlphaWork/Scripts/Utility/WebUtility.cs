using System;

namespace AlphaWork
{
    public static class WebUtility
    {
        public static string EscapeString(string stringToEscape)
        {
            if (null == stringToEscape)
                return null;
            return Uri.EscapeDataString(stringToEscape);
        }

        public static string UnescapeString(string stringToUnescape)
        {
            return Uri.UnescapeDataString(stringToUnescape);
        }
    }
}
