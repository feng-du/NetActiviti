using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DateDataObject : ValuedDataObject
    {

        public override void SetValue(object value)
        {
            this.value = (DateTime)value;
        }

        public override BaseElement Clone()
        {
            DateDataObject clone = new DateDataObject();
            clone.SetValues(this);
            return clone;
        }
    }
}
