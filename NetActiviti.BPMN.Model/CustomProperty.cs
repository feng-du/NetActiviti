using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class CustomProperty : BaseElement
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string simpleValue;
        public string SimpleValue
        {
            get { return simpleValue; }
            set { simpleValue = value; }
        }

        private IComplexDataType complexValue;
        public IComplexDataType ComplexValue
        {
            get { return complexValue; }
            set { complexValue = value; }
        }



        public override BaseElement Clone()
        {
            CustomProperty clone = new CustomProperty();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(CustomProperty otherProperty)
        {
            name = otherProperty.Name;
            simpleValue = otherProperty.SimpleValue;

            if (otherProperty.ComplexValue != null && otherProperty.ComplexValue is DataGrid)
            {
                complexValue = ((DataGrid)(otherProperty.ComplexValue)).Clone();
            }
        }
    }

}
