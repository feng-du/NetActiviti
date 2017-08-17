using NetActiviti.BPMN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public interface IValidator
    {

        void Validate(BpmnModel bpmnModel, List<ValidationError> errors);

    }
}
