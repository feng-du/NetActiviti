using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ErrorEventDefinition : EventDefinition
    {

        private string errorCode;
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }


        public override BaseElement Clone()
        {
            ErrorEventDefinition clone = new ErrorEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ErrorEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            errorCode = otherDefinition.ErrorCode;
        }
    }
}
