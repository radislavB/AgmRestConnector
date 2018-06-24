using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Core
{
    public class ParameterInfo : DictionaryBasedEntity
    {
        public static string VALUE_FIELD = "value";

        #region Ctors

        public ParameterInfo()
            : base()
        {
        }

        public ParameterInfo(IDictionary<string, object> properties)
            : base(properties)
        {
        }

        public ParameterInfo(String value)
        {
            Value = value;


        }

        #endregion

        #region Base Properties



        public string Value
        {
            get
            {
                return GetStringValue(VALUE_FIELD);
            }
            set
            {
                SetValue(VALUE_FIELD, value);
            }

        }



        #endregion
    }
}
