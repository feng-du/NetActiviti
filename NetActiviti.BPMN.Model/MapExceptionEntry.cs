using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class MapExceptionEntry
    {

        public MapExceptionEntry(string errorCode, string className, bool andChildren)
        {

            this.errorCode = errorCode;
            this.className = className;
            this.andChildren = andChildren;
        }

        private string errorCode;
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private bool andChildren;
        public bool IsAndChildren
        {
            get { return andChildren; }
            set { andChildren = value; }
        }

    }
}
