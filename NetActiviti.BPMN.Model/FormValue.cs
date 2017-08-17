using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class FormValue : BaseElement
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override BaseElement Clone()
        {
            FormValue clone = new FormValue();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(FormValue otherValue)
        {
            base.SetValues(otherValue);
            name = otherValue.Name;
        }
    }
}
