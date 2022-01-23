using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CatalogsManager.Aspects.Logging
{
    public static class LoggingStatics
    {
        public static string GetStringMetadata<T>(T request)
        {
            var type = request.GetType();
            var properties = new List<PropertyInfo>(type.GetProperties());

            var properiesValues = properties
                .Select(property => $"{property.Name}: {property.GetValue(request)}");

            return string.Join("; ", properiesValues);
        }

        public static Dictionary<string, object> GetProperties<T>(T parametrObject)
        {
            var type = parametrObject.GetType();

            return type.GetProperties()
                .ToDictionary(
                    property => property.Name,
                    property => property.GetValue(parametrObject));
        }
    }
}
