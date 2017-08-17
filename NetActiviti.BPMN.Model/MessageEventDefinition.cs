using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class MessageEventDefinition : EventDefinition
    {

        private string messageRef;
        private string messageExpression;

        public string MessageRef
        {
            get { return messageRef; }
            set { messageRef = value; }
        }


        public string MessageExpression
        {
            get { return messageExpression; }
            set { messageExpression = value; }
        }


        public override BaseElement Clone()
        {
            MessageEventDefinition clone = new MessageEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(MessageEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            messageRef = otherDefinition.MessageRef;
            messageExpression = otherDefinition.MessageExpression;
        }
    }
}
