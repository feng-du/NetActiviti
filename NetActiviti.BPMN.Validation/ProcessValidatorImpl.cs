using NetActiviti.BPMN.Model;
using NetActiviti.Process.Validation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation
{
    public class ProcessValidatorImpl : IProcessValidator
    {

        protected List<ValidatorSet> validatorSets;

        public List<ValidatorSet> ValidatorSets
        {
            get { return validatorSets; }
            set { validatorSets = value; }
        }

        public List<ValidationError> Validate(BpmnModel bpmnModel)
        {

            List<ValidationError> allErrors = new List<ValidationError>();

            foreach (ValidatorSet validatorSet in validatorSets)
            {
                foreach (IValidator validator in validatorSet.Validators)
                {
                    List<ValidationError> validatorErrors = new List<ValidationError>();
                    validator.Validate(bpmnModel, validatorErrors);
                    if (!(validatorErrors.Count < 0))
                    {
                        foreach (ValidationError error in validatorErrors)
                        {
                            error.setValidatorSetName(validatorSet.Name);
                        }
                        allErrors.AddRange(validatorErrors);
                    }
                }
            }
            return allErrors;
        }

        public List<ValidatorSet> GetValidatorSets()
        {
            return validatorSets;
        }



        public void AddValidatorSet(ValidatorSet validatorSet)
        {
            if (validatorSets == null)
            {
                validatorSets = new List<ValidatorSet>();
            }
            validatorSets.Add(validatorSet);
        }

    }
}
