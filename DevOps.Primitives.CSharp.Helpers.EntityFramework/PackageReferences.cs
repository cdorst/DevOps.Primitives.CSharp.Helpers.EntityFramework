using DevOps.Primitives.NuGet;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class PackageReferences
    {
        public static NuGetReference CDorstDevOpsPrimitivesStrings() => new NuGetReference("CDorst.DevOps.Primitives.Strings", "1.0.4");
        public static NuGetReference MicrosoftEntityFrameworkCore() => new NuGetReference("Microsoft.EntityFrameworkCore", "2.1.0-preview1-final");
        public static NuGetReference ProtobufNet() => new NuGetReference("protobuf-net", "2.3.7");
    }
}
