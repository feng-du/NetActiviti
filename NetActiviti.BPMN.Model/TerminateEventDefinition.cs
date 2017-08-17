using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class TerminateEventDefinition : EventDefinition
    {

        /**
         * When true, this event will terminate all parent process instances (in the case of using call activity),
         * thus ending the whole process instance.
         * 
         * By default false (BPMN spec compliant): the parent scope is terminated (subprocess: embedded or call activity)
         */
        private bool terminateAll;

        /**
         * When true (and used within a multi instance), this event will terminate all multi instance instances 
         * of the embedded subprocess/call activity this event is used in. 
         * 
         * In case of nested multi instance, only the first parent multi instance structure will be destroyed.
         * In case of 'true' and not being in a multi instance construction: executes the default behavior.
         * 
         * Note: if terminate all is set to true, this will have precedence over this.
         */
        private bool terminateMultiInstance;



        public bool IsTerminateAll
        {
            get { return terminateAll; }
            set { terminateAll = value; }
        }


        public bool IsTerminateMultiInstance
        {
            get { return terminateMultiInstance; }
            set { terminateMultiInstance = value; }
        }

        public override BaseElement Clone()
        {
            TerminateEventDefinition clone = new TerminateEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(TerminateEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            this.terminateAll = otherDefinition.IsTerminateAll;
            this.terminateMultiInstance = otherDefinition.IsTerminateMultiInstance;
        }
    }
}
