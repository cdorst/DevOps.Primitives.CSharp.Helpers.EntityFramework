namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class EntityProperty
    {
        public string Name { get; set; }
        public string SummaryComment { get; set; }
        public string Type { get; set; }
        public string TypeNamespace { get; set; }
        public EntityPropertyReferenceInfo ReferenceInfo { get; set; }

        public bool IsReference => ReferenceInfo != null;
    }
}
