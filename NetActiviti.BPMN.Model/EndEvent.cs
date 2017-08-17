using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class EndEvent : Event
    {

        public override BaseElement Clone()
        {
            EndEvent clone = new EndEvent();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(EndEvent otherEvent)
        {
            base.SetValues(otherEvent);
        }
    }
}
