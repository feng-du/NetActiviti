using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Assignment : BaseElement
    {


        private string from;
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        private string to;
        public string To
        {
            get { return to; }
            set { to = value; }
        }


        public override BaseElement Clone()
        {
            Assignment clone = new Assignment();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Assignment otherAssignment)
        {
            from = otherAssignment.From;
            to = otherAssignment.To;
        }
    }
}
