using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructorArguments
    {
        public static ArgumentList List(
            IEnumerable<EntityConstructorProperty> arguments)
            => ArgumentLists.Create(
                arguments.Select(argument => Argument(argument)).ToArray());

        private static Argument Argument(EntityConstructorProperty argument)
            => Arguments.Argument(argument.ArgumentMap);
    }
}
