using NetActiviti.BPMN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetActiviti;

namespace NetActiviti.Process.Validation.Validator
{
    public abstract class ValidatorImpl : IValidator
    {

        public void AddError(List<ValidationError> validationErrors, ValidationError error)
        {
            validationErrors.Add(error);
        }

        protected void AddError(List<ValidationError> validationErrors, String problem, String description)
        {
            AddError(validationErrors, problem, null, null, description, false);
        }

        protected void AddError(List<ValidationError> validationErrors, String problem, BaseElement baseElement, String description)
        {
            AddError(validationErrors, problem, null, baseElement, description);
        }

        protected void AddError(List<ValidationError> validationErrors, String problem, BPMN.Model.Process process, BaseElement baseElement, String description)
        {
            AddError(validationErrors, problem, process, baseElement, description, false);
        }

        protected void addWarning(List<ValidationError> validationErrors, String problem, BPMN.Model.Process process, BaseElement baseElement, String description)
        {
            AddError(validationErrors, problem, process, baseElement, description, true);
        }

        protected void AddError(List<ValidationError> validationErrors, String problem, BPMN.Model.Process process, BaseElement baseElement, String description, bool isWarning)
        {
            ValidationError error = new ValidationError();
            error.IsWarning = isWarning;

            if (process != null)
            {
                error.setProcessDefinitionId(process.Id);
                error.setProcessDefinitionName(process.Name);
            }

            if (baseElement != null)
            {
                error.setXmlLineNumber(baseElement.XmlRowNumber);
                error.setXmlColumnNumber(baseElement.XmlColumnNumber);
            }
            error.setProblem(problem);
            error.setDefaultDescription(description);

            if (baseElement is FlowElement)
            {
                FlowElement flowElement = (FlowElement)baseElement;
                error.setActivityId(flowElement.Id);
                error.setActivityName(flowElement.Name);
            }

            AddError(validationErrors, error);
        }

        protected void AddError(List<ValidationError> validationErrors, String problem, BPMN.Model.Process process, String id, String description)
        {
            ValidationError error = new ValidationError();

            if (process != null)
            {
                error.setProcessDefinitionId(process.Id);
                error.setProcessDefinitionName(process.Name);
            }

            error.setProblem(problem);
            error.setDefaultDescription(description);
            error.setActivityId(id);

            AddError(validationErrors, error);
        }

        public abstract void Validate(BpmnModel bpmnModel, List<ValidationError> errors);
    }
}
