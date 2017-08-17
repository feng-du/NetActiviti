using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class FormProperty : BaseElement
    {

        private string name;
        private string expression;
        private string variable;
        private string type;
        private string defaultExpression;
        private string datePattern;
        private bool readable = true;
        private bool writeable = true;
        private bool required;
        private List<FormValue> formValues = new List<FormValue>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }


        public string Variable
        {
            get { return variable; }
            set { variable = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string DefaultExpression
        {
            get { return defaultExpression; }
            set { defaultExpression = value; }
        }



        public string DatePattern
        {
            get { return datePattern; }
            set { datePattern = value; }
        }


        public bool IsReadable
        {
            get { return readable; }
            set { readable = value; }
        }


        public bool IsWriteable
        {
            get { return writeable; }
            set { writeable = value; }
        }


        public bool IsRequired
        {
            get { return required; }
            set { required = value; }
        }


        public List<FormValue> FormValues
        {
            get { return formValues; }
            set { formValues = value == null ? new List<FormValue>() : value; }
        }


        public override BaseElement Clone()
        {
            FormProperty clone = new FormProperty();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(FormProperty otherProperty)
        {
            base.SetValues(otherProperty);
            name = otherProperty.Name;
            expression = otherProperty.Expression;
            variable = otherProperty.Variable;
            type = otherProperty.Type;
            defaultExpression = otherProperty.DefaultExpression;
            datePattern = otherProperty.DatePattern;
            readable = otherProperty.IsReadable;
            writeable = otherProperty.IsWriteable;
            required = otherProperty.IsRequired;

            formValues = new List<FormValue>();
            if (otherProperty.FormValues != null && otherProperty.FormValues.Count > 0)
            {
                foreach (FormValue formValue in otherProperty.FormValues)
                {
                    formValues.Add((FormValue)formValue.Clone());
                }
            }
        }
    }
}
