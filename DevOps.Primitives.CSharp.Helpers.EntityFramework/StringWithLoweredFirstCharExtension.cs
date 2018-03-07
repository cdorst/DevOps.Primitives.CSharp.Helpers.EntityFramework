namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    internal static class StringWithLoweredFirstCharExtension
    {
        public static string WithLoweredFirstChar(this string instance)
            => $"{instance[0].ToString().ToLower()}{instance.Substring(1)}";
    }
}
