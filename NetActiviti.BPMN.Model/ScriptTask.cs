using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ScriptTask : Task
    {

        private string scriptFormat;
        private string script;
        private string resultVariable;
        private bool autoStoreVariables = false; // see
                                                 // https://activiti.atlassian.net/browse/ACT-1626

        public string ScriptFormat
        {
            get { return scriptFormat; }
            set { scriptFormat = value; }
        }

        public string Script
        {
            get { return script; }
            set { script = value; }
        }


        public string ResultVariable
        {
            get { return resultVariable; }
            set { resultVariable = value; }
        }


        public bool IsAutoStoreVariables
        {
            get { return autoStoreVariables; }
            set { autoStoreVariables = value; }
        }


        public override BaseElement Clone()
        {
            ScriptTask clone = new ScriptTask();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ScriptTask otherElement)
        {
            base.SetValues(otherElement);
            scriptFormat = otherElement.ScriptFormat;
            script = otherElement.Script;
            resultVariable = otherElement.ResultVariable;
            autoStoreVariables = otherElement.IsAutoStoreVariables;
        }
    }
}
