using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataGridField : BaseElement
    {


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public override BaseElement Clone()
        {
            DataGridField clone = new DataGridField();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataGridField otherField)
        {
            name = otherField.Name;
            _value = otherField.Value;
        }
    }
}
