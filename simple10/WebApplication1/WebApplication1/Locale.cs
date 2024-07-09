using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace WebApplication1
{
    public class Locale : CultureInfo, IParsable<Locale>
    {
        public Locale(string culture) : base(culture)
        {
        }
        public static Locale Parse(string s, IFormatProvider? provider)
        {
            if (!TryParse(s, provider, out var locale))
            {
                throw new Exception("设置本地化信息错误");
            }
            return locale;
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Locale locale)
        {
            if (s is null)
            {
                locale = new Locale(CurrentCulture.Name);
                return false;
            }

            try
            {
                locale = new Locale(s);
                return true;
            }
            catch (Exception ex)
            {
                locale = new Locale(CurrentCulture.Name);
                return false;
            }
        }
    }
}
