namespace CQS.Demo.ConsoleApp.Extensions
{
    public static class StringExtensions
    {
        public static string WithEllipsis(this string value, int maxLength)
        {
            var str = value ?? "";

            return str.Length > maxLength
                ? $"{str.Substring(0, maxLength)}..."
                : str;
        }
    }
}
