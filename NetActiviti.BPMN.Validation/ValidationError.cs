using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation
{
    public class ValidationError
    {

        protected String validatorSetName;

        protected String problem;

        // Default description in english.
        // Other languages can map the validatorSetName/validatorName to the
        // translated version.
        protected String defaultDescription;

        protected String processDefinitionId;

        protected String processDefinitionName;

        protected int xmlLineNumber;

        protected int xmlColumnNumber;

        protected String activityId;

        protected String activityName;

        protected bool isWarning;

        public String getValidatorSetName()
        {
            return validatorSetName;
        }

        public void setValidatorSetName(String validatorSetName)
        {
            this.validatorSetName = validatorSetName;
        }

        public String getProblem()
        {
            return problem;
        }

        public void setProblem(String problem)
        {
            this.problem = problem;
        }

        public String getDefaultDescription()
        {
            return defaultDescription;
        }

        public void setDefaultDescription(String defaultDescription)
        {
            this.defaultDescription = defaultDescription;
        }

        public String getProcessDefinitionId()
        {
            return processDefinitionId;
        }

        public void setProcessDefinitionId(String processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
        }

        public String getProcessDefinitionName()
        {
            return processDefinitionName;
        }

        public void setProcessDefinitionName(String processDefinitionName)
        {
            this.processDefinitionName = processDefinitionName;
        }

        public int getXmlLineNumber()
        {
            return xmlLineNumber;
        }

        public void setXmlLineNumber(int xmlLineNumber)
        {
            this.xmlLineNumber = xmlLineNumber;
        }

        public int getXmlColumnNumber()
        {
            return xmlColumnNumber;
        }

        public void setXmlColumnNumber(int xmlColumnNumber)
        {
            this.xmlColumnNumber = xmlColumnNumber;
        }

        public String getActivityId()
        {
            return activityId;
        }

        public void setActivityId(String activityId)
        {
            this.activityId = activityId;
        }

        public String getActivityName()
        {
            return activityName;
        }

        public void setActivityName(String activityName)
        {
            this.activityName = activityName;
        }

        public bool IsWarning
        {
            get { return isWarning; }
            set { isWarning = value; }
        }

      public override String ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("[Validation set: '" + validatorSetName + "' | Problem: '" + problem + "'] : ");
            strb.Append(defaultDescription);
            strb.Append(" - [Extra info : ");
            bool extraInfoAlreadyPresent = false;
            if (processDefinitionId != null)
            {
                strb.Append("processDefinitionId = " + processDefinitionId);
                extraInfoAlreadyPresent = true;
            }
            if (processDefinitionName != null)
            {
                if (extraInfoAlreadyPresent)
                {
                    strb.Append(" | ");
                }
                strb.Append("processDefinitionName = " + processDefinitionName + " | ");
                extraInfoAlreadyPresent = true;
            }
            if (activityId != null)
            {
                if (extraInfoAlreadyPresent)
                {
                    strb.Append(" | ");
                }
                strb.Append("id = " + activityId + " | ");
                extraInfoAlreadyPresent = true;
            }
            if (activityName != null)
            {
                if (extraInfoAlreadyPresent)
                {
                    strb.Append(" | ");
                }
                strb.Append("activityName = " + activityName + " | ");
                extraInfoAlreadyPresent = true;
            }
            strb.Append("]");
            if (xmlLineNumber > 0 && xmlColumnNumber > 0)
            {
                strb.Append(" ( line: " + xmlLineNumber + ", column: " + xmlColumnNumber + ")");
            }
            return strb.ToString();
        }

    }
}
