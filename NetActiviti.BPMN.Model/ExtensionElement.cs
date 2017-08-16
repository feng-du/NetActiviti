using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ExtensionElement : BaseElement
    {
        private string elementText;
        public string ElementText
        {
            get { return elementText; }
            set { elementText = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string namespacePrefix;
        public string NamespacePrefix
        {
            get { return namespacePrefix; }
            set { namespacePrefix = value; }
        }

        private string _namespace;
        public string NameSpace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }

        private Dictionary<string, List<ExtensionElement>> childElements = new Dictionary<string, List<ExtensionElement>>();
        public Dictionary<string, List<ExtensionElement>> ChildElements
        {
            get { return childElements; }
            set { childElements = value == null ? new Dictionary<string, List<ExtensionElement>>() : value; }
        }

        public void AddChildElement(ExtensionElement childElement)
        {
            if (childElement != null && (!string.IsNullOrEmpty(childElement.Name)))
            {
                List<ExtensionElement> elementList = null;
                if (!this.childElements.ContainsKey(childElement.Name))
                {
                    elementList = new List<ExtensionElement>();
                    this.childElements.Add(childElement.Name, elementList);
                }
                this.childElements[childElement.Name].Add(childElement);
            }
        }


        public override BaseElement Clone()
        {
            ExtensionElement clone = new ExtensionElement();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ExtensionElement otherElement)
        {

            name = otherElement.Name;
            namespacePrefix = otherElement.NamespacePrefix;
            _namespace = otherElement.NameSpace;
            elementText = otherElement.ElementText;
            attributes = otherElement.attributes;

            childElements = new Dictionary<string, List<ExtensionElement>>();
            if (otherElement.ChildElements != null && otherElement.ChildElements.Count() > 0)
            {
                foreach (string key in otherElement.ChildElements.Keys)
                {
                    List<ExtensionElement> otherElementList = otherElement.ChildElements[key];
                    if (otherElementList != null && otherElementList.Count > 0)
                    {
                        List<ExtensionElement> elementList = new List<ExtensionElement>();
                        foreach (ExtensionElement extensionElement in otherElementList)
                        {
                            elementList.Add((ExtensionElement)extensionElement.Clone());
                        }
                        childElements.Add(key, elementList);
                    }
                }
            }
        }
    }
}
