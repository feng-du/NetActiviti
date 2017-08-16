using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public interface IFlowElementsContainer
    {
        FlowElement GetFlowElement(string id);

        List<FlowElement> GetFlowElements();

        void AddFlowElement(FlowElement element);

        void AddFlowElementToMap(FlowElement element);

        void RemoveFlowElement(string elementId);

        void RemoveFlowElementFromMap(string elementId);

        Artifact GetArtifact(string id);

        List<Artifact> GetArtifacts();

        void AddArtifact(Artifact artifact);

        void RemoveArtifact(string artifactId);
    }
}
