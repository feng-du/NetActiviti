using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class SendTask : TaskWithFieldExtensions
    {

        private string type;
        private string implementationType;
        private string operationRef;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public string ImplementationType
        {
            get { return implementationType; }
            set { implementationType = value; }
        }

        public string OperationRef
        {
            get { return operationRef; }
            set { operationRef = value; }
        }


        public override BaseElement Clone()
        {
            SendTask clone = new SendTask();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(SendTask otherElement)
        {
            base.SetValues(otherElement);
            type = otherElement.Type;
            implementationType = otherElement.ImplementationType;
            operationRef = otherElement.OperationRef;

            FieldExtensions = new List<FieldExtension>();
            if (otherElement.FieldExtensions != null && otherElement.FieldExtensions.Count > 0)
            {
                foreach (FieldExtension extension in otherElement.FieldExtensions)
                {
                    FieldExtensions.Add((FieldExtension)extension.Clone());
                }
            }
        }
    }
}
