namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class DbContextProperty
    {
        public string PropertyNameOverride { get; set; }
        public string SqlSchema { get; set; }
        public string SqlTableName { get; set; }
        public string TypeName { get; set; }
        public string TypeNamespace { get; set; }
    }
}
