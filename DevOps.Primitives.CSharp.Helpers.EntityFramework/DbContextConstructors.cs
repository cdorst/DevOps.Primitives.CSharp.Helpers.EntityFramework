namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextConstructors
    {
        private const string ArgumentName = "options";
        private const string ArgumentType = "DbContextOptions";

        public static Constructor Create(string typeName)
            => new Constructor(
                typeName,
                new Block(),
                ModifierLists.Private,
                new ParameterList(ArgumentName, ArgumentType),
                constructorBaseInitializer: GetBaseInitializer());

        private static ConstructorBaseInitializer GetBaseInitializer()
            => new ConstructorBaseInitializer(
                new ArgumentList(ArgumentName));
    }
}
