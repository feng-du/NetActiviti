using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DoubleDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = Double.Parse(value.ToString());
        }

        public override BaseElement Clone()
        {
            DoubleDataObject clone = new DoubleDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
