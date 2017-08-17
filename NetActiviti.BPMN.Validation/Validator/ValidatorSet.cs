using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public class ValidatorSet
    {

        protected String name;

        protected Dictionary<Type, IValidator> validators;

        public ValidatorSet(String name)
        {
            this.name = name;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        public List<IValidator> Validators
        {
            get { return validators.Values.ToList(); }
            set
            {
                foreach (IValidator validator in value)
                {
                    AddValidator(validator);
                }
            }
        }


        public void RemoveValidator(Type validatorClass)
        {
            validators.Remove(validatorClass);
        }

        public void AddValidator(IValidator validator)
        {
            if (validators == null)
            {
                validators = new Dictionary<Type, IValidator>();
            }
            validators.Add(validator.GetType(), validator);
        }

    }
}
