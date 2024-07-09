using System.Diagnostics.CodeAnalysis;

namespace WebApplication1
{
    public class DateRange2
    {
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }


        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out DateRange2 result)
        {
            var segment = s.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (segment.Length == 2
                && DateOnly.TryParse(segment[0], provider, out var f)
                && DateOnly.TryParse(segment[1], provider, out var t)
                )
            {
                result = new DateRange2() { From = f, To = t };
                return true;
            }

            result = new DateRange2() { From = default, To = default };
            return false;

        }
    }
}
