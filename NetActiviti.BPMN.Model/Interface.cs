using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Interface : BaseElement
    {

        private string name;
        private string implementationRef;
        private List<Operation> operations = new List<Operation>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string ImplementationRef
        {
            get { return implementationRef; }
            set { implementationRef = value; }
        }


        public List<Operation> Operations
        {
            get { return operations; }
            set { operations = value == null ? new List<Operation>() : value; }
        }


        public override BaseElement Clone()
        {
            Interface clone = new Interface();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Interface otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            implementationRef = otherElement.ImplementationRef;

            operations = new List<Operation>();
            if (otherElement.Operations != null && otherElement.Operations.Count > 0)
            {
                foreach (Operation operation in otherElement.Operations)
                {
                    operations.Add((Operation)operation.Clone());
                }
            }
        }
    }
}
