using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class BooleanDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = Boolean.Parse(value.ToString());
        }

        public override BaseElement Clone()

        {
            BooleanDataObject clone = new BooleanDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
