using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class EventGateway : Gateway
    {

        public override BaseElement Clone()
        {
            EventGateway clone = new EventGateway();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(EventGateway otherElement)
        {
            base.SetValues(otherElement);
        }
    }

}
