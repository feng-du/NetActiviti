using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class SequenceFlow : FlowElement
    {

        public SequenceFlow()
        {

        }

        public SequenceFlow(String sourceRef, String targetRef)
        {
            this.sourceRef = sourceRef;
            this.targetRef = targetRef;
        }

        private string conditionExpression;
        public string ConditionExpression
        {
            get { return conditionExpression; }
            set { conditionExpression = value; }
        }

        private string sourceRef;
        public string SourceRef
        {
            get { return sourceRef; }
            set { sourceRef = value; }
        }

        private string targetRef;
        public string TargetRef
        {
            get { return targetRef; }
            set { targetRef = value; }
        }

        private string skipExpression;
        public string SkipExpression
        {
            get { return skipExpression; }
            set { skipExpression = value; }
        }

        // Actual flow elements that match the source and target ref
        // Set during process definition parsing
        private FlowElement sourceFlowElement;
        [JsonIgnore]
        public FlowElement SourceFlowElement
        {
            get { return sourceFlowElement; }
            set { sourceFlowElement = value; }
        }

        private FlowElement targetFlowElement;
        [JsonIgnore]
        public FlowElement TargetFlowElement
        {
            get { return targetFlowElement; }
            set { targetFlowElement = value; }
        }

        /**
         * Graphical information: a list of waypoints: x1, y1, x2, y2, x3, y3, ..
         * 
         * Added during parsing of a process definition.
         */
        private List<int> waypoints = new List<int>();
        public List<int> Waypoints
        {
            get { return waypoints; }
            set { waypoints = value; }
        }


        public override string ToString()
        {
            return sourceRef + " --> " + targetRef;
        }

        public override BaseElement Clone()
        {
            SequenceFlow clone = new SequenceFlow();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(SequenceFlow otherFlow)
        {
            base.SetValues(otherFlow);
            conditionExpression = otherFlow.ConditionExpression;
            sourceRef = otherFlow.SourceRef;
            targetRef = otherFlow.TargetRef;
            skipExpression = otherFlow.SkipExpression;
        }
    }
}
