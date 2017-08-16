using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class CompensateEventDefinition : EventDefinition
    {


        private string activityRef;
        public string ActivityRef
        {
            get { return activityRef; }
            set { activityRef = value; }
        }


        private bool waitForCompletion = true;
        public bool IsWaitForCompletion
        {
            get { return waitForCompletion; }
            set { waitForCompletion = value; }
        }



        public override BaseElement Clone()
        {
            CompensateEventDefinition clone = new CompensateEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(CompensateEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            activityRef = otherDefinition.ActivityRef;
            waitForCompletion = otherDefinition.IsWaitForCompletion;
        }
    }
}
