using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class BoundaryEvent : Event
    {
        private Activity attachedToRef;
        [JsonIgnore]
        public Activity AttachedToRef
        {
            get { return attachedToRef; }
            set { attachedToRef = value; }
        }

        private string attachedToRefId;
        public string AttachedToRefId
        {
            get { return attachedToRefId; }
            set { attachedToRefId = value; }
        }


        private bool cancelActivity = true;
        public bool IsCancelActivity
        {
            get { return cancelActivity; }
            set { cancelActivity = value; }
        }


        public override BaseElement Clone()
        {
            BoundaryEvent clone = new BoundaryEvent();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(BoundaryEvent otherEvent)
        {
            base.SetValues(otherEvent);
            attachedToRefId = otherEvent.AttachedToRefId;
            attachedToRef = otherEvent.AttachedToRef;
            cancelActivity = otherEvent.IsCancelActivity;
        }
    }
}
