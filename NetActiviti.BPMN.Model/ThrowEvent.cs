using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ThrowEvent : Event
    {

        public override BaseElement Clone()
        {
            ThrowEvent clone = new ThrowEvent();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ThrowEvent otherEvent)
        {
            base.SetValues(otherEvent);
        }
    }

}
