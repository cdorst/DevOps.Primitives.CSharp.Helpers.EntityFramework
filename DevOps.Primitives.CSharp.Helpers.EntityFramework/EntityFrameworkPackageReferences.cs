using DevOps.Primitives.NuGet;
using System.Collections.Generic;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.PackageReferences;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityFrameworkPackageReferences
    {
        public static IEnumerable<NuGetReference> GetEntityFrameworkCoreReferences()
        {
            yield return MicrosoftEntityFrameworkCore();
            yield return ProtobufNet();
        }
    }
}
