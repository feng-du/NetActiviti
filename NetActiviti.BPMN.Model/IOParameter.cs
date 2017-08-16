using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class IOParameter : BaseElement
    {

        private string source;
        public string Source
        {
            get { return source; }
            set { source = value; }
        }


        private string target;
        public string Target
        {
            get { return target; }
            set { target = value; }
        }


        private string sourceExpression;
        public string SourceExpression
        {
            get { return sourceExpression; }
            set { sourceExpression = value; }
        }


        private string targetExpression;
        public string TargetExpression
        {
            get { return targetExpression; }
            set { targetExpression = value; }
        }



        public override BaseElement Clone()
        {
            IOParameter clone = new IOParameter();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(IOParameter otherElement)
        {
            base.SetValues(otherElement);
            source = otherElement.Source;
            sourceExpression = otherElement.SourceExpression;
            target = otherElement.Target;
            targetExpression = otherElement.TargetExpression;
        }
    }
}
