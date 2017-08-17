using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ExclusiveGateway : Gateway
    {

        public override BaseElement Clone()
        {
            ExclusiveGateway clone = new ExclusiveGateway();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ExclusiveGateway otherElement)
        {
            base.SetValues(otherElement);
        }
    }
}
