using DevOps.Primitives.NuGet;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityFrameworkPackageReferences
    {
        public static IEnumerable<NuGetReference> GetEntityFrameworkCoreReferences()
        {
            yield return PackageReferences.MicrosoftEntityFrameworkCore();
            yield return PackageReferences.ProtobufNet();
        }
    }
}
