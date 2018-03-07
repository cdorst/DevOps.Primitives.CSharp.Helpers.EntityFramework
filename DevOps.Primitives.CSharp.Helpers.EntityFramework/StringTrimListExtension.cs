namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    internal static class StringTrimListExtension
    {
        public static string TrimList(this string instance)
            => instance.Substring(0, instance.Length - 4);
    }
}
