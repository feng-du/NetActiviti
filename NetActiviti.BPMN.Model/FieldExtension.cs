using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class FieldExtension : BaseElement
    {
        public FieldExtension()
        {

        }

        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        private string stringValue;
        public string StringValue
        {
            get { return stringValue; }
            set { value = stringValue; }
        }

        private string expression;
        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }


        public override BaseElement Clone()
        {
            FieldExtension clone = new FieldExtension();
            clone.setValues(this);
            return clone;
        }

        public void setValues(FieldExtension otherExtension)
        {

            fieldName = otherExtension.FieldName;
            stringValue = otherExtension.StringValue;
            expression = otherExtension.Expression;
        }
    }
}
