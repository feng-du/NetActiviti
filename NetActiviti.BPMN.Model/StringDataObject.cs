using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class StringDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = value.ToString();
        }

        public override BaseElement Clone()
        {
            StringDataObject clone = new StringDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
