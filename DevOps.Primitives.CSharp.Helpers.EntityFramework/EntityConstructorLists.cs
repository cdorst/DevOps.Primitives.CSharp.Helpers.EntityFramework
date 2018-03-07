using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;
using static DevOps.Primitives.CSharp.Helpers.Common.Constructors;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityConstructorArguments;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityConstructors;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntitySpecialCaseDerivatives;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructorLists
    {
        public static ConstructorList Create(string name, IEnumerable<EntityProperty> properties, List<Constructor> constructed = null, IEnumerable<EntityConstructorProperty> derivedProperties = null, ArgumentList arguments = null)
        {
            if (!Any(constructed))
                return Create(name, properties, new List<Constructor>
                {
                    Default(name),
                    BaseCase(name, properties)
                });

            if (arguments != null)
                constructed.Add(Linked(name, properties, arguments));

            var specialCases = properties.Where(p => p.SpecialType != null);
            if (Any(specialCases))
            {
                var derived = PropertyDerivatives(properties);
                return Create(name, derived.Select(d => d.PropertyDerivative),
                    constructed, derived, List(derivedProperties));
            }
            return ConstructorLists.Create(constructed.ToArray());
        }
    }
}
