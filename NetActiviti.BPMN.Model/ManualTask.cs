using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ManualTask : Task
    {

        public override BaseElement Clone()
        {
            ManualTask clone = new ManualTask();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ManualTask otherElement)
        {
            base.SetValues(otherElement);
        }
    }

}
