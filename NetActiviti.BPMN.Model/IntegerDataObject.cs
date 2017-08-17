using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class IntegerDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = int.Parse(value.ToString());
        }

        public override BaseElement Clone()
        {
            IntegerDataObject clone = new IntegerDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
