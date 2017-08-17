using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class LongDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = long.Parse(value.ToString());
        }

        public override BaseElement Clone()
        {
            LongDataObject clone = new LongDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
