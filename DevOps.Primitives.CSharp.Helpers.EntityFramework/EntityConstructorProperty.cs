namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class EntityConstructorProperty
    {
        public EntityConstructorProperty(EntityProperty property, EntityProperty derivative)
        {
            Property = property;
            PropertyDerivative = derivative;
        }

        public string ArgumentMap { get; set; }
        public EntityProperty Property { get; set; }
        public EntityProperty PropertyDerivative { get; set; }

        public EntityConstructorProperty WithArgument(string argument)
        {
            ArgumentMap = argument;
            return this;
        }

        public EntityConstructorProperty WithNewTypeArgument(string type, string arguments)
            => WithArgument($"new {type}({arguments})");
    }
}
