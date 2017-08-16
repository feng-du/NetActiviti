using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class BaseElement : IHasExtensionAttributes
    {


        /** extension attributes could be part of each element */
        protected Dictionary<string, List<ExtensionAttribute>> attributes = new Dictionary<string, List<ExtensionAttribute>>();

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private int xmlRowNumber;
        public int XmlRowNumber
        {
            get { return xmlRowNumber; }
            set { xmlRowNumber = value; }
        }

        private int xmlColumnNumber;
        public int XmlColumnNumber
        {
            get { return xmlColumnNumber; }
            set { xmlColumnNumber = value; }
        }

        private Dictionary<string, List<ExtensionElement>> extensionElements = new Dictionary<string, List<ExtensionElement>>();
        public Dictionary<string, List<ExtensionElement>> ExtensionElements
        {
            get { return extensionElements; }
            set { extensionElements = value == null ? new Dictionary<string, List<ExtensionElement>>() : value; }
        }


        public void AddExtensionElement(ExtensionElement extensionElement)
        {
            if (extensionElement != null && (!string.IsNullOrEmpty(extensionElement.Name)))
            {
                List<ExtensionElement> elementList = null;
                if (!this.extensionElements.ContainsKey(extensionElement.Name))
                {
                    elementList = new List<ExtensionElement>();
                    this.extensionElements.Add(extensionElement.Name, elementList);
                }
                this.extensionElements[extensionElement.Name].Add(extensionElement);
            }
        }



        public Dictionary<string, List<ExtensionAttribute>> GetAttributes()
        {
            return attributes;
        }


        public string GetAttributeValue(string _namespace, string name)
        {
            List<ExtensionAttribute> attributes = GetAttributes()[name];
            if (attributes != null && attributes.Count > 0)
            {
                foreach (ExtensionAttribute attribute in attributes)
                {
                    if ((_namespace == null && attribute.NameSpace == null) || _namespace == attribute.NameSpace)
                        return attribute.Value;
                }
            }
            return null;
        }


        public void AddAttribute(ExtensionAttribute attribute)
        {
            if (attribute != null && (!string.IsNullOrEmpty(attribute.Name)))
            {
                List<ExtensionAttribute> attributeList = null;
                if (!this.attributes.ContainsKey(attribute.Name))
                {
                    attributeList = new List<ExtensionAttribute>();
                    this.attributes.Add(attribute.Name, attributeList);
                }
                this.attributes[attribute.Name].Add(attribute);
            }
        }


        public void SetAttributes(Dictionary<String, List<ExtensionAttribute>> attributes)
        {
            this.attributes = attributes;
        }

        public void SetValues(BaseElement otherElement)
        {
            id = otherElement.Id;

            extensionElements = new Dictionary<string, List<ExtensionElement>>();
            if (otherElement.ExtensionElements != null && otherElement.ExtensionElements.Count > 0)
            {
                foreach (string key in otherElement.ExtensionElements.Keys)
                {
                    List<ExtensionElement> otherElementList = otherElement.ExtensionElements[key];
                    if (otherElementList != null && otherElementList.Count > 0)
                    {
                        List<ExtensionElement> elementList = new List<ExtensionElement>();
                        foreach (ExtensionElement extensionElement in otherElementList)
                        {
                            elementList.Add((ExtensionElement)extensionElement.Clone());
                        }
                        extensionElements.Add(key, elementList);
                    }
                }
            }

            attributes = new Dictionary<string, List<ExtensionAttribute>>();
            if (otherElement.GetAttributes() != null && otherElement.GetAttributes().Count > 0)
            {
                foreach (string key in otherElement.GetAttributes().Keys)
                {
                    List<ExtensionAttribute> otherAttributeList = otherElement.GetAttributes()[key];
                    if (otherAttributeList != null && otherAttributeList.Count > 0)
                    {
                        List<ExtensionAttribute> attributeList = new List<ExtensionAttribute>();
                        foreach (ExtensionAttribute extensionAttribute in otherAttributeList)
                        {
                            attributeList.Add(extensionAttribute.Clone());
                        }
                        attributes.Add(key, attributeList);
                    }
                }
            }
        }

        public abstract BaseElement Clone();
    }
}
