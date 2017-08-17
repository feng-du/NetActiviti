using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ParallelGateway : Gateway
    {

        public override BaseElement Clone()
        {
            ParallelGateway clone = new ParallelGateway();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ParallelGateway otherElement)
        {
            base.SetValues(otherElement);
        }
    }

}
