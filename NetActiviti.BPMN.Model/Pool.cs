using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Pool : BaseElement
    {

        private string name;
        private string processRef;
        private bool executable = true;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ProcessRef
        {
            get { return processRef; }
            set { processRef = value; }
        }


        public bool IsExecutable
        {
            get { return this.executable; }
            set { executable = value; }
        }


        public override BaseElement Clone()
        {
            Pool clone = new Pool();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Pool otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            processRef = otherElement.ProcessRef;
            executable = otherElement.IsExecutable;
        }
    }

}
