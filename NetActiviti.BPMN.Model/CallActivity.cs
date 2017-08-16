using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class CallActivity : Activity
    {
        private string calledElement;
        public String CalledElement
        {
            get { return calledElement; }
            set { calledElement = value; }
        }


        private bool inheritVariables;
        public bool IsInheritVariables
        {
            get { return inheritVariables; }
            set { inheritVariables = value; }
        }


        private List<IOParameter> inParameters = new List<IOParameter>();
        public List<IOParameter> InParameters
        {
            get { return inParameters; }
            set { inParameters = value; }
        }

        private List<IOParameter> outParameters = new List<IOParameter>();
        public List<IOParameter> OutParameters
        {
            get { return outParameters; }
            set { outParameters = value; }
        }

        private string businessKey;
        public string BusinessKey
        {
            get { return businessKey; }
            set { businessKey = value; }
        }

        private bool inheritBusinessKey;
        public bool IsInheritBusinessKey
        {
            get { return inheritBusinessKey; }
            set { inheritBusinessKey = value; }
        }



        public override BaseElement Clone()
        {
            CallActivity clone = new CallActivity();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(CallActivity otherElement)
        {
            base.SetValues(otherElement);
            calledElement = otherElement.CalledElement;
            businessKey = otherElement.BusinessKey;
            inheritBusinessKey = otherElement.IsInheritBusinessKey;

            inParameters = new List<IOParameter>();
            if (otherElement.InParameters != null && otherElement.InParameters.Count > 0)
            {
                foreach (IOParameter parameter in otherElement.InParameters)
                {
                    inParameters.Add((IOParameter)parameter.Clone());
                }
            }

            outParameters = new List<IOParameter>();
            if (otherElement.OutParameters != null && otherElement.OutParameters.Count > 0)
            {
                foreach (IOParameter parameter in otherElement.OutParameters)
                {
                    outParameters.Add((IOParameter)parameter.Clone());
                }
            }
        }
    }
}
