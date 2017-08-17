using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class SignalEventDefinition : EventDefinition
    {

        private string signalRef;
        private string signalExpression;
        private bool async;

        public string SignalRef
        {
            get { return signalRef; }
            set { signalRef = value; }
        }


        public string SignalExpression
        {
            get { return signalExpression; }
            set { signalExpression = value; }
        }


        public bool IsAsync
        {
            get { return async; }
            set { async = value; }
        }


        public override BaseElement Clone()
        {
            SignalEventDefinition clone = new SignalEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(SignalEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            signalRef = otherDefinition.SignalRef;
            signalExpression = otherDefinition.SignalExpression;
            async = otherDefinition.IsAsync;
        }
    }
}
