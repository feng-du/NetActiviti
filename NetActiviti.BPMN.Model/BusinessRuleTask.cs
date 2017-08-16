using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class BusinessRuleTask : Task
    {

        private bool exclude;
        public bool IsExclude
        {
            get { return exclude; }
            set { exclude = value; }
        }


        private string resultVariableName;
        public string ResultVariableName
        {
            get { return resultVariableName; }
            set { resultVariableName = value; }
        }

        private List<string> ruleNames = new List<string>();
        public List<string> RuleNames
        {
            get { return ruleNames; }
            set { ruleNames = value == null ? new List<string>() : value; }
        }


        private List<string> inputVariables = new List<string>();
        public List<string> InputVariables
        {
            get { return inputVariables; }
            set { inputVariables = value; }
        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }



        public override BaseElement Clone()
        {
            BusinessRuleTask clone = new BusinessRuleTask();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(BusinessRuleTask otherElement)
        {
            base.SetValues(otherElement);
            resultVariableName = otherElement.ResultVariableName;
            exclude = otherElement.IsExclude;
            className = otherElement.ClassName;
            ruleNames = new List<string>(otherElement.RuleNames);
            inputVariables = new List<string>(otherElement.InputVariables);
        }
    }
}
