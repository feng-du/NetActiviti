using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model.Parse
{
    public class Problem
    {

        protected string errorMessage;
        protected string resource;
        protected int line;
        protected int column;

        public Problem(string errorMessage, string localName, int lineNumber, int columnNumber)
        {
            this.errorMessage = errorMessage;
            this.resource = localName;
            this.line = lineNumber;
            this.column = columnNumber;
        }

        public Problem(string errorMessage, BaseElement element)
        {
            this.errorMessage = errorMessage;
            this.resource = element.Id;
            this.line = element.XmlRowNumber;
            this.column = element.XmlColumnNumber;
        }

        public Problem(string errorMessage, GraphicInfo graphicInfo)
        {
            this.errorMessage = errorMessage;
            this.line = graphicInfo.XmlRowNumber;
            this.column = graphicInfo.XmlColumnNumber;
        }

        public override string ToString()
        {
            return errorMessage + (resource != null ? " | " + resource : "") + " | line " + line + " | column " + column;
        }
    }
}
