using System.Diagnostics.CodeAnalysis;

namespace WebApplication1
{
    public class DateRange : IParsable<DateRange>
    {
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public static DateRange Parse(string s, IFormatProvider? provider)
        {
            if (!TryParse(s, provider ,out var result))
            {
                throw new Exception("转换失败");
            }
            return result;
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out DateRange result)
        {
            var segment = s.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (segment.Length == 2
                && DateOnly.TryParse(segment[0], provider, out var f)
                && DateOnly.TryParse(segment[1], provider, out var t)
                )
            {
                result = new DateRange() { From = f, To = t };
                return true;
            }

            result = new DateRange() { From = default, To = default };
            return false;

        }
    }
}
