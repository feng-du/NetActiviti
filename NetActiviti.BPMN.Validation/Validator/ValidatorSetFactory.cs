using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public class ValidatorSetFactory
    {

        public ValidatorSet CreateActivitiExecutableProcessValidatorSet()
        {
            ValidatorSet validatorSet = new ValidatorSet(ValidatorSetNames.ACTIVITI_EXECUTABLE_PROCESS);

            validatorSet.AddValidator(new AssociationValidator());
            validatorSet.AddValidator(new SignalValidator());
            validatorSet.AddValidator(new OperationValidator());
            validatorSet.AddValidator(new ErrorValidator());
            validatorSet.AddValidator(new DataObjectValidator());

            validatorSet.AddValidator(new BpmnModelValidator());
            validatorSet.AddValidator(new FlowElementValidator());

            validatorSet.AddValidator(new StartEventValidator());
            validatorSet.AddValidator(new SequenceflowValidator());
            validatorSet.AddValidator(new UserTaskValidator());
            validatorSet.AddValidator(new ServiceTaskValidator());
            validatorSet.AddValidator(new ScriptTaskValidator());
            validatorSet.AddValidator(new SendTaskValidator());
            validatorSet.AddValidator(new ExclusiveGatewayValidator());
            validatorSet.AddValidator(new EventGatewayValidator());
            validatorSet.AddValidator(new SubprocessValidator());
            validatorSet.AddValidator(new EventSubprocessValidator());
            validatorSet.AddValidator(new BoundaryEventValidator());
            validatorSet.AddValidator(new IntermediateCatchEventValidator());
            validatorSet.AddValidator(new IntermediateThrowEventValidator());
            validatorSet.AddValidator(new MessageValidator());
            validatorSet.AddValidator(new EventValidator());
            validatorSet.AddValidator(new EndEventValidator());

            validatorSet.AddValidator(new ExecutionListenerValidator());
            validatorSet.AddValidator(new ActivitiEventListenerValidator());

            validatorSet.AddValidator(new DiagramInterchangeInfoValidator());

            return validatorSet;
        }

    }
}
