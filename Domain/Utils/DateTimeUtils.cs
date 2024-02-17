namespace Domain.Utils;

public static class DateTimeUtils {
    public static bool CompareDates(this DateTimeOffset source, DateTimeOffset toCompare) =>
        source.Day == toCompare.Day
        && source.Month == toCompare.Month
        && source.Year == toCompare.Year;
}