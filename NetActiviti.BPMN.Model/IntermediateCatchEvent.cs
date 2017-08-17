using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class IntermediateCatchEvent : Event
    {

        public override BaseElement Clone()
        {
            IntermediateCatchEvent clone = new IntermediateCatchEvent();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(IntermediateCatchEvent otherEvent)
        {
            base.SetValues(otherEvent);
        }
    }
}
