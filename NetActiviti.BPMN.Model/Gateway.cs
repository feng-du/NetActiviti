using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class Gateway : FlowNode
    {

        private string defaultFlow;
        public string DefaultFlow
        {
            get { return defaultFlow; }
            set { defaultFlow = value; }
        }


        //public abstract Gateway clone();

        public void SetValues(Gateway otherElement)
        {
            base.SetValues(otherElement);
            defaultFlow = otherElement.DefaultFlow;
        }
    }
}