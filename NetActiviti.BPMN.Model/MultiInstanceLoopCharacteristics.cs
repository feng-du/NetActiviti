using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class MultiInstanceLoopCharacteristics : BaseElement
    {

        private string inputDataItem;
        public string InputDataItem
        {
            get { return inputDataItem; }
            set { inputDataItem = value; }
        }


        private string loopCardinality;
        public string LoopCardinality
        {
            get { return loopCardinality; }
            set { loopCardinality = value; }
        }


        private string completionCondition;
        public string CompletionCondition
        {
            get { return completionCondition; }
            set { completionCondition = value; }
        }


        private string elementVariable;
        public string ElementVariable
        {
            get { return elementVariable; }
            set { elementVariable = value; }
        }


        private string elementIndexVariable;
        public string ElementIndexVariable
        {
            get { return elementIndexVariable; }
            set { elementIndexVariable = value; }
        }


        private bool sequential;
        public bool IsSequential
        {
            get { return sequential; }
            set { sequential = value; }
        }


        public override BaseElement Clone()
        {
            MultiInstanceLoopCharacteristics clone = new MultiInstanceLoopCharacteristics();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(MultiInstanceLoopCharacteristics otherLoopCharacteristics)
        {
            inputDataItem = otherLoopCharacteristics.InputDataItem;
            loopCardinality = otherLoopCharacteristics.LoopCardinality;
            completionCondition = otherLoopCharacteristics.CompletionCondition;
            elementVariable = otherLoopCharacteristics.ElementVariable;
            elementIndexVariable = otherLoopCharacteristics.ElementIndexVariable;
            sequential = otherLoopCharacteristics.IsSequential;
        }
    }
}
