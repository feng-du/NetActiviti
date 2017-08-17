using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class MessageFlow : BaseElement
    {

        private string name;
        private string sourceRef;
        private string targetRef;
        private string messageRef;

        public MessageFlow()
        {

        }

        public MessageFlow(string sourceRef, string targetRef)
        {
            this.sourceRef = sourceRef;
            this.targetRef = targetRef;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string SourceRef
        {
            get { return sourceRef; }
            set { sourceRef = value; }
        }


        public string TargetRef
        {
            get { return targetRef; }
            set { targetRef = value; }
        }


        public string MessageRef
        {
            get { return messageRef; }
            set { messageRef = value; }
        }


        public override string ToString()
        {
            return sourceRef + " --> " + targetRef;
        }

        public override BaseElement Clone()
        {
            MessageFlow clone = new MessageFlow();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(MessageFlow otherFlow)
        {
            base.SetValues(otherFlow);
            name = otherFlow.Name;
            sourceRef = otherFlow.SourceRef;
            targetRef = otherFlow.TargetRef;
            messageRef = otherFlow.MessageRef;
        }
    }
}
