using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityUsings
    {
        private const string ProtoBuf = nameof(ProtoBuf);
        private const string SystemComponentModelDataAnnotations = "System.ComponentModel.DataAnnotations";
        private const string SystemComponentModelDataAnnotationsSchema = "System.ComponentModel.DataAnnotations.Schema";

        public static UsingDirectiveList Create(params string[] usings)
            => UsingDirectiveLists.Create(
                GetUsings(usings));

        private static string[] GetUsings(IEnumerable<string> usings)
        {
            var set = new HashSet<string>
            {
                ProtoBuf,
                SystemComponentModelDataAnnotations,
                SystemComponentModelDataAnnotationsSchema
            };
            foreach (var @using in usings) if (!string.IsNullOrWhiteSpace(@using)) set.Add(@using);
            return set.ToArray();
        }
    }
}
