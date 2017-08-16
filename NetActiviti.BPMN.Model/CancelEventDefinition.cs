using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class CancelEventDefinition : EventDefinition
    {

        public override BaseElement Clone()
        {
            CancelEventDefinition clone = new CancelEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(CancelEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
        }
    }
}
