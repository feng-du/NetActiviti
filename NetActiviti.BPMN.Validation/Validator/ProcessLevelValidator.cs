using NetActiviti.BPMN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public abstract class ProcessLevelValidator : ValidatorImpl
    {

        public override void Validate(BpmnModel bpmnModel, List<ValidationError> errors)
        {
            foreach (BPMN.Model.Process process in bpmnModel.Processes)
            {
                ExecuteValidation(bpmnModel, process, errors);
            }
        }

        protected abstract void ExecuteValidation(BpmnModel bpmnModel, BPMN.Model.Process process, List<ValidationError> errors);

    }
}
