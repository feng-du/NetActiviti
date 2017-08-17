using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model.Parse
{
    public class Warning
    {

        protected string warningMessage;
        protected string resource;
        protected int line;
        protected int column;

        public Warning(string warningMessage, string localName, int lineNumber, int columnNumber)
        {
            this.warningMessage = warningMessage;
            this.resource = localName;
            this.line = lineNumber;
            this.column = columnNumber;
        }

        public Warning(string warningMessage, BaseElement element)
        {
            this.warningMessage = warningMessage;
            this.resource = element.Id;
            line = element.XmlRowNumber;
            column = element.XmlColumnNumber;
        }

        public override string ToString()
        {
            return warningMessage + (resource != null ? " | " + resource : "") + " | line " + line + " | column " + column;
        }
    }
}
