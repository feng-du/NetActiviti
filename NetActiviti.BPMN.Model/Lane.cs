using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetActiviti.BPMN.Model
{
    public class Lane : BaseElement
    {

        private string name;
        private Process parentProcess;
        private List<string> flowReferences = new List<string>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [JsonIgnore]
        public Process ParentProcess
        {
            get { return parentProcess; }
            set { parentProcess = value; }
        }


        public List<string> FlowReferences
        {
            get { return flowReferences; }
            set { flowReferences = value == null ? new List<string>() : value; }
        }


        public override BaseElement Clone()
        {
            Lane clone = new Lane();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Lane otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            parentProcess = otherElement.ParentProcess;

            flowReferences = new List<string>();
            if (otherElement.FlowReferences != null && otherElement.FlowReferences.Count > 0)
            {
                flowReferences.AddRange(otherElement.FlowReferences);
            }
        }
    }
}
