using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class UniqueIndex
    {
        public string Entity { get; set; }
        public IEnumerable<string> Fields { get; set; }
    }
}
