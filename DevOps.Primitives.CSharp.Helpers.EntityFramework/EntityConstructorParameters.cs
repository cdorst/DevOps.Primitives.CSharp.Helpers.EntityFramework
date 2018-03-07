using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructorParameters
    {
        public static ParameterList Parameters(IEnumerable<EntityProperty> parameters)
            => ParameterLists.Create(
                parameters.Select(argument => Param(argument)).ToArray());

        private static Parameter Param(EntityProperty argument)
            => new Parameter(
                argument.Name.WithLoweredFirstChar(),
                argument.Type);
    }
}
