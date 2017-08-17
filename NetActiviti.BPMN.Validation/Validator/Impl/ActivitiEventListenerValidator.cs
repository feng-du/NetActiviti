using NetActiviti.BPMN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator.Impl
{
    public class ActivitiEventListenerValidator : ProcessLevelValidator
    {

        protected override void ExecuteValidation(BpmnModel bpmnModel, BPMN.Model.Process process, List<ValidationError> errors)
        {
            List<EventListener> eventListeners = process.EventListeners;
            if (eventListeners != null)
            {
                foreach (EventListener eventListener in eventListeners)
                {

                    if (eventListener.ImplementationType != null && eventListener.ImplementationType == ImplementationType.IMPLEMENTATION_TYPE_INVALID_THROW_EVENT)
                    {

                        AddError(errors, Problems.EVENT_LISTENER_INVALID_THROW_EVENT_TYPE, process, eventListener, "Invalid or unsupported throw event type on event listener");

                    }
                    else if (eventListener.ImplementationType == null || eventListener.ImplementationType.Length == 0)
                    {

                        AddError(errors, Problems.EVENT_LISTENER_IMPLEMENTATION_MISSING, process, eventListener, "Element 'class', 'delegateExpression' or 'throwEvent' is mandatory on eventListener");

                    }
                    else if (eventListener.ImplementationType != null)
                    {

                        if (!ImplementationType.IMPLEMENTATION_TYPE_CLASS.Equals(eventListener.ImplementationType)
                            && !ImplementationType.IMPLEMENTATION_TYPE_DELEGATEEXPRESSION.Equals(eventListener.ImplementationType)
                            && !ImplementationType.IMPLEMENTATION_TYPE_THROW_SIGNAL_EVENT.Equals(eventListener.ImplementationType)
                            && !ImplementationType.IMPLEMENTATION_TYPE_THROW_GLOBAL_SIGNAL_EVENT.Equals(eventListener.ImplementationType)
                            && !ImplementationType.IMPLEMENTATION_TYPE_THROW_MESSAGE_EVENT.Equals(eventListener.ImplementationType)
                            && !ImplementationType.IMPLEMENTATION_TYPE_THROW_ERROR_EVENT.Equals(eventListener.ImplementationType))
                        {
                            AddError(errors, Problems.EVENT_LISTENER_INVALID_IMPLEMENTATION, process, eventListener, "Unsupported implementation type for event listener");
                        }

                    }

                }

            }
        }

    }
}
