namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructorAssignmentStatements
    {
        public static Statement Assignment(string name)
            => new Statement(GetAssignment(name));

        public static Statement Assignment(EntityProperty argument)
            => Assignment(argument.Name);

        private static string GetAssignment(string name)
            => $"{name} = {name.WithLoweredFirstChar()};";
    }
}
