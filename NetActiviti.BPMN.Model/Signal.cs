using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Signal : BaseElement
    {

        public static readonly string SCOPE_GLOBAL = "global";
        public static readonly string SCOPE_PROCESS_INSTANCE = "processInstance";

        private string name;

        private string scope;

        public Signal()
        {
        }

        public Signal(string id, string name)
        {
            this.Id = id;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Scope
        {
            get { return scope; }
            set { scope = value; }
        }


        public override BaseElement Clone()
        {
            Signal clone = new Signal();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Signal otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            scope = otherElement.Scope;
        }
    }
}
