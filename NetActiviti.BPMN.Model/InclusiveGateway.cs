using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class InclusiveGateway : Gateway
    {

        public override BaseElement Clone()
        {
            InclusiveGateway clone = new InclusiveGateway();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(InclusiveGateway otherElement)
        {
            base.SetValues(otherElement);
        }
    }

}
