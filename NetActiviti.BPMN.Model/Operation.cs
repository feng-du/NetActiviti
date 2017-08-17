using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Operation : BaseElement
    {

        protected string name;
        protected string implementationRef;
        protected string inMessageRef;
        protected string outMessageRef;
        protected List<string> errorMessageRef = new List<string>();

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


        public string InMessageRef
        {
            get { return inMessageRef; }
            set { inMessageRef = value; }
        }


        public string OutMessageRef
        {
            get { return outMessageRef; }
            set { outMessageRef = value; }
        }


        public List<string> ErrorMessageRef
        {
            get { return errorMessageRef; }
            set { errorMessageRef = value == null?new List<string>():value; }
        }


        public override BaseElement Clone()
        {
            Operation clone = new Operation();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Operation otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            implementationRef = otherElement.ImplementationRef;
            inMessageRef = otherElement.InMessageRef;
            outMessageRef = otherElement.OutMessageRef;

            errorMessageRef = new List<string>();
            if (otherElement.ErrorMessageRef != null && otherElement.ErrorMessageRef.Count > 0)
            {
                errorMessageRef.AddRange(otherElement.ErrorMessageRef);
            }
        }
    }
}
