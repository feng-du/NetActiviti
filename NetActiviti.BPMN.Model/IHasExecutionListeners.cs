using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    /// <summary>
    /// Interface indicating an element has execution-listeners
    /// </summary>
    public interface IHasExecutionListeners
    {
        List<ActivitiListener> GetExecutionListeners();

        void SetExecutionListeners(List<ActivitiListener> executionListeners);
    }
}
