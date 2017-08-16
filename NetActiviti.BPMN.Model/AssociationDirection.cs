using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{ 

    public enum AssociationDirection
    {
        [Description("None")]
        NONE,

        [Description("One")]
        ONE,

        [Description("Both")]
        BOTH
    }

    public static class AssociationDirectionExtensions
    {
        public static string GetValue(this AssociationDirection environment)
        {
            // get the field 
            var field = environment.GetType().GetField(environment.ToString());
            var customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (customAttributes.Length > 0)
            {
                return (customAttributes[0] as DescriptionAttribute).Description;
            }
            else
            {
                throw new Exception("Can not read AssociationDirection Description Attribute. ");
            }
        }
    }

}
