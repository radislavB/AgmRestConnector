using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;

namespace Hpe.Agm.RestConnector.Core
{
    public class BaseEntityJsonConverter : JavaScriptConverter
    {

        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                List<Type> types = FindAllDerivedTypes<DictionaryBasedEntity>();
                return types;
            }
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (obj == null) return new Dictionary<string, object>();
            DictionaryBasedEntity entity = ((DictionaryBasedEntity)obj);

            IDictionary<string, object> properties = new Dictionary<string, object>(entity.GetProperties());
            return properties;
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            DictionaryBasedEntity entity = (DictionaryBasedEntity)Activator.CreateInstance(type);
            entity.SetProperties(dictionary);
            return entity;
        }

        private static List<Type> FindAllDerivedTypes<T>()
        {
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        private static List<Type> FindAllDerivedTypes<T>(Assembly assembly)
        {
            var derivedType = typeof(T);
            return assembly.GetTypes().Where(t => t != derivedType && derivedType.IsAssignableFrom(t)).ToList();
        }
    }
}
