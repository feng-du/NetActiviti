using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class FlowNode : FlowElement
    {

    protected bool asynchronous;
    protected bool notExclusive;

    public FlowNode()
    {

    }

    public bool IsAsynchronous
    {
        get { return asynchronous; }
    }

    public void SetAsynchronous(bool asynchronous)
    {
        this.asynchronous = asynchronous;
    }

    public bool IsExclusive
    {
        get { return !notExclusive; }
    }

    public void SetExclusive(bool exclusive)
    {
        this.notExclusive = !exclusive;
    }

    public bool IsNotExclusive
    {
        get { return notExclusive; }
    }
    public void SetNotExclusive(bool notExclusive)
    {
        this.notExclusive = notExclusive;
    }

        private object behavior;
        [JsonIgnore]
        public object Behavior
        {
            get { return behavior; }
            set { behavior = value; }
        }

        private List<SequenceFlow> incomingFlows = new List<SequenceFlow>();
        public List<SequenceFlow> IncomingFlows
    {
        get { return incomingFlows; }
            set { incomingFlows = value; }
    }

        private List<SequenceFlow> outgoingFlows = new List<SequenceFlow>();
        public List<SequenceFlow> OutgoingFlows
    {
        get { return outgoingFlows; }
            set { outgoingFlows = value; }
    }

   

    public void SetValues(FlowNode otherNode)
    {
        base.SetValues(otherNode);
        SetAsynchronous(otherNode.IsAsynchronous);
        SetNotExclusive(otherNode.IsNotExclusive);
    }
}
}
