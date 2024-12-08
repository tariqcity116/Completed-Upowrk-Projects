using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassReader
{
    internal class ClassHelper
    {
        private List<object> visitedObjects;
        public string GetPropertiesAndValues(object obj)
        {
            if (obj == null)
                return "Object is null";

            visitedObjects = new List<object>();
            return ProcessObject(obj);
        }

        private string ProcessObject(object obj)
        {
            if (visitedObjects.Contains(obj))
            {
                return "Circular reference detected.";
            }

            visitedObjects.Add(obj);

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{type.Name} (ClassName)");
            result.AppendLine("---------");

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                bool isPrimitive = propertyType.IsPrimitive || propertyType == typeof(string);
                if (!(!isPrimitive && property.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))))
                {
                    result.AppendLine($"{property.Name} = {property.GetValue(obj)}");
                }
                
                if (!isPrimitive && property.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    int index = 1;
                    var isFirstTime = true;
                    foreach (var item in (IEnumerable)property.GetValue(obj))
                    {
                        if(isFirstTime)
                        {
                            result.AppendLine($"List<{Convert.ToString(item.GetType())}> =>");
                            isFirstTime = false;
                        }
                      
                        result.AppendLine($"{index++}:");
                        foreach (var subProperty in item.GetType().GetProperties())
                        {
                            if (!string.IsNullOrWhiteSpace(Convert.ToString(subProperty.GetValue(item))))
                                result.AppendLine($"{subProperty.Name} = {subProperty.GetValue(item)}");
                        }
                    }
                }
                else if (property.PropertyType != typeof(string) && !property.PropertyType.IsValueType)
                {
                    result.AppendLine($"{property.Name} = {ProcessObject(property.GetValue(obj))}");
                }
            }

            visitedObjects.Remove(obj);
            return result.ToString();
        }
    }
}
