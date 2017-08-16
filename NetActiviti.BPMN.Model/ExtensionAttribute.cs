using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ExtensionAttribute
    {
        public ExtensionAttribute()
        {
        }

        public ExtensionAttribute(string name)
        {
            this._name = name;
        }

        public ExtensionAttribute(string xmlnamespace, string name)
        {
            this._namespace = xmlnamespace;
            this._name = name;
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }



        private string _value;
        public string Value
        {
            get { return this._value; }
            set { _value = value; }
        }

        private string _namespacePrefix;
        public string NamespacePrefix
        {
            get { return _namespacePrefix; }
            set { _namespacePrefix = value; }
        }


        private string _namespace;
        public string NameSpace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_namespacePrefix != null)
            {
                sb.Append(_namespacePrefix);
                if (_name != null)
                    sb.Append(":").Append(_name);
            }
            else
                sb.Append(_name);
            if (_value != null)
                sb.Append("=").Append(_value);
            return sb.ToString();
        }

        public ExtensionAttribute Clone()
        {
            ExtensionAttribute clone = new ExtensionAttribute();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ExtensionAttribute otherAttribute)
        {
            _name = otherAttribute.Name;
            _value = otherAttribute.Value;
            _namespace = otherAttribute.NameSpace;
            _namespacePrefix = otherAttribute.NamespacePrefix;

        }
    }
}
