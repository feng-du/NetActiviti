using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class AdhocSubProcess : SubProcess
    {

        public static readonly string ORDERING_PARALLEL = "Parallel";
        public static readonly string ORDERING_SEQUENTIALL = "Sequential";

        private string completionCondition;
        public string CompletionCondition
        {
            get { return completionCondition; }
            set { completionCondition = value; }
        }

        private string ordering = ORDERING_PARALLEL;
        public string Ordering
        {
            get { return ordering; }
            set { ordering = value; }
        }


        public bool HasParallelOrdering()
        {
            return !ORDERING_SEQUENTIALL.Equals(ordering);
        }

        public bool HasSequentialOrdering()
        {
            return ORDERING_SEQUENTIALL.Equals(ordering);
        }

        private bool cancelRemainingInstances = true;
        public bool IsCancelRemainingInstances
        {
            get { return cancelRemainingInstances; }
            set { cancelRemainingInstances = value; }
        }

    }
}
