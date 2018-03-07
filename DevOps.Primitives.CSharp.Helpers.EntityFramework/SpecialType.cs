namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public enum SpecialType : byte
    {
        AsciiStringReference,
        AsciiMaxStringReference,
        UnicodeStringReference,
        UnicodeMaxStringReference,
        StringReference,

        List,
        ListAssociation,
        ListAssociationList,

        BinaryShortReference,
        BinaryMaxReference,
        BinaryReference,

        ByteReference,
        BytePairReference,
        ByteTreeReference
    }
}
