using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ComplexGateway : Gateway
    {

        public override BaseElement Clone()
        {
            ComplexGateway clone = new ComplexGateway();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ComplexGateway otherElement)
        {
            base.SetValues(otherElement);
        }
    }
}
