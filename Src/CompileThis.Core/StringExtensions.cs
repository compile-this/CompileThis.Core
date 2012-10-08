namespace CompileThis
{
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces the format items in the string with the string value of the corresponding arguments.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
