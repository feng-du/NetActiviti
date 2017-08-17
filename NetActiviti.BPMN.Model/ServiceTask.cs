using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ServiceTask : TaskWithFieldExtensions
    {

        public static readonly string DMN_TASK = "dmn";
        public static readonly string MAIL_TASK = "mail";

        private string implementation;
        private string implementationType;
        private string resultVariableName;
        private string type;
        private string operationRef;
        private string extensionId;
        private List<CustomProperty> customProperties = new List<CustomProperty>();
        private string skipExpression;

        public string Implementation
        {
            get { return implementation; }
            set { implementation = value; }
        }


        public string ImplementationType
        {
            get { return implementationType; }
            set { implementationType = value; }
        }


        public string ResultVariableName
        {
            get { return resultVariableName; }
            set { resultVariableName = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public List<CustomProperty> CustomProperties
        {
            get { return customProperties; }
            set { customProperties = value == null ? new List<CustomProperty>() : value; }
        }


        public string OperationRef
        {
            get { return operationRef; }
            set { operationRef = value; }
        }


        public string ExtensionId
        {
            get { return extensionId; }
            set { extensionId = value; }
        }


        public bool IsExtended
        {
            get { return !string.IsNullOrEmpty(extensionId); }
        }

        public string SkipExpression
        {
            get { return skipExpression; }
            set { skipExpression = value; }
        }


        public override BaseElement Clone()
        {
            ServiceTask clone = new ServiceTask();
            clone.SetValues(this);
            return clone;
        }

        public void setValues(ServiceTask otherElement)
        {
            base.SetValues(otherElement);
            implementation = otherElement.Implementation;
            implementationType = otherElement.ImplementationType;
            resultVariableName = otherElement.ResultVariableName;
            type = otherElement.Type;
            operationRef = otherElement.OperationRef;
            extensionId = otherElement.ExtensionId;
            skipExpression = otherElement.SkipExpression;

            FieldExtensions = new List<FieldExtension>();
            if (otherElement.FieldExtensions != null && otherElement.FieldExtensions.Count > 0)
            {
                foreach (FieldExtension extension in otherElement.FieldExtensions)
                {
                    FieldExtensions.Add((FieldExtension)extension.Clone());
                }
            }

            customProperties = new List<CustomProperty>();
            if (otherElement.CustomProperties != null && otherElement.CustomProperties.Count > 0)
            {
                foreach (CustomProperty property in otherElement.CustomProperties)
                {
                    customProperties.Add((CustomProperty)property.Clone());
                }
            }
        }
    }
}
