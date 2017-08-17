using NetActiviti.Process.Validation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation
{
    public class ProcessValidatorFactory
    {

        public IProcessValidator CreateDefaultProcessValidator()
        {
            ProcessValidatorImpl processValidator = new ProcessValidatorImpl();
            processValidator.AddValidatorSet(new ValidatorSetFactory().CreateActivitiExecutableProcessValidatorSet());
            return processValidator;
        }

    }
}
