using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    /// <summary>
    /// interface for accessing Element attributes.
    /// </summary>
    public interface IHasExtensionAttributes
    {
        /** get element's attributes */
        Dictionary<string, List<ExtensionAttribute>> GetAttributes();

        /**
         * return value of the attribute from given namespace with given name.
         * 
         * @param namespace
         * @param name
         * @return attribute value or null in case when attribute was not found
         */
        string GetAttributeValue(string _namespace, string name);

        /** add attribute to the object */
        void AddAttribute(ExtensionAttribute attribute);

        /** set all object's attributes */
        void SetAttributes(Dictionary<string, List<ExtensionAttribute>> attributes);
    }
}
