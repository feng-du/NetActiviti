using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class FlowElement : BaseElement, IHasExecutionListeners
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string documentation;
        public string Documentation
        {
            get { return documentation; }
            set { documentation = value; }
        }

        private List<ActivitiListener> executionListeners = new List<ActivitiListener>();
        public List<ActivitiListener> GetExecutionListeners()
        {
            return executionListeners;
        }

        public void SetExecutionListeners(List<ActivitiListener> executionListeners)
        {
            this.executionListeners = executionListeners == null ? new List<ActivitiListener>() : executionListeners;
        }


        private IFlowElementsContainer parentContainer;
        [JsonIgnore]
        public IFlowElementsContainer ParentContainer
        {
            get { return parentContainer; }
            set { parentContainer = value; }
        }


        [JsonIgnore]
        public SubProcess SubProcess
        {
            get
            {
                SubProcess subProcess = null;
                if (parentContainer is SubProcess)
                {
                    subProcess = (SubProcess)parentContainer;
                }

                return subProcess;
            }

        }



        //public abstract FlowElement Clone();

        public void SetValues(FlowElement otherElement)
        {

            base.SetValues(otherElement);
            name = otherElement.Name;
            documentation = otherElement.Documentation;

            executionListeners = new List<ActivitiListener>();
            if (otherElement.GetExecutionListeners() != null && otherElement.GetExecutionListeners().Count > 0)
            {
                foreach (ActivitiListener listener in otherElement.GetExecutionListeners())
                {
                    executionListeners.Add((ActivitiListener)listener.Clone());
                }
            }
        }
    }
}
