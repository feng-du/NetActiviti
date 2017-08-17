using NetActiviti.BPMN.Model;
using NetActiviti.Process.Validation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation
{

    /**
     * Validates a process definition against the rules of the Activiti engine to be executable
     * 

     */
    public interface IProcessValidator
    {

        /**
         * Validates the provided {@link BpmnModel} and returns a list of all {@link ValidationError} occurences found.
         */
        List<ValidationError> Validate(BpmnModel bpmnModel);

        /**
         * Returns the {@link ValidatorSet} instances for this process validator. Useful if some validation rules need to be disabled.
         */
        List<ValidatorSet> GetValidatorSets();

    }
}
