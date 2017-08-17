using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class SubProcess : Activity, IFlowElementsContainer
    {

        public FlowElement GetFlowElement(string id)
        {
            FlowElement foundElement = null;
            if (!string.IsNullOrEmpty(id))
            {
                foundElement = flowElementMap[id];
            }
            return foundElement;
        }

        private List<FlowElement> flowElementList = new List<FlowElement>();
        public List<FlowElement> FlowElements
        {
            get { return flowElementList; }
        }

        public List<FlowElement> GetFlowElements()
        {
            return flowElementList;
        }

        public void AddFlowElement(FlowElement element)
        {
            flowElementList.Add(element);
            element.ParentContainer = this;
            if (!string.IsNullOrEmpty(element.Id))
            {
                flowElementMap.Add(element.Id, element);
                if (ParentContainer != null)
                {
                    ParentContainer.AddFlowElementToMap(element);
                }
            }
        }

        public void AddFlowElementToMap(FlowElement element)
        {
            if (element != null && (!string.IsNullOrEmpty(element.Id)))
            {
                flowElementMap.Add(element.Id, element);
                if (ParentContainer != null)
                {
                    ParentContainer.AddFlowElementToMap(element);
                }
            }
        }

        public void RemoveFlowElement(string elementId)
        {
            FlowElement element = GetFlowElement(elementId);
            if (element != null)
            {
                flowElementList.Remove(element);
                flowElementMap.Remove(elementId);
                if (element.ParentContainer != null)
                {
                    element.ParentContainer.RemoveFlowElementFromMap(elementId);
                }
            }
        }

        public void RemoveFlowElementFromMap(string elementId)
        {
            if (!string.IsNullOrEmpty(elementId))
            {
                flowElementMap.Remove(elementId);
            }
        }

        private Dictionary<string, FlowElement> flowElementMap = new Dictionary<string, FlowElement>();
        public Dictionary<string, FlowElement> FlowElementMap
        {
            get { return flowElementMap; }
            set { flowElementMap = value == null ? new Dictionary<string, FlowElement>() : value; }
        }



        public bool ContainsFlowElementId(string id)
        {
            return flowElementMap.ContainsKey(id);
        }

        public Artifact GetArtifact(string id)
        {
            Artifact foundArtifact = null;
            foreach (Artifact artifact in artifactList)
            {
                if (id == artifact.Id)
                {
                    foundArtifact = artifact;
                    break;
                }
            }
            return foundArtifact;
        }

        private List<Artifact> artifactList = new List<Artifact>();
        public List<Artifact> Artifacts
        {
            get { return artifactList; }
        }

        public List<Artifact> GetArtifacts()
        {
            return artifactList;
        }

        public void AddArtifact(Artifact artifact)
        {
            artifactList.Add(artifact);
        }

        public void RemoveArtifact(string artifactId)
        {
            Artifact artifact = GetArtifact(artifactId);
            if (artifact != null)
            {
                artifactList.Remove(artifact);
            }
        }

        public override BaseElement Clone()
        {
            SubProcess clone = new SubProcess();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(SubProcess otherElement)
        {
            base.SetValues(otherElement);

            /*
             * This is required because data objects in Designer have no DI info and are added as properties, not flow elements
             * 
             * Determine the differences between the 2 elements' data object
             */
            foreach (ValuedDataObject thisObject in DataObjects)
            {
                bool exists = false;
                foreach (ValuedDataObject otherObject in otherElement.DataObjects)
                {
                    if (thisObject.Id == otherObject.Id)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    // missing object
                    RemoveFlowElement(thisObject.Id);
                }
            }

            dataObjects = new List<ValuedDataObject>();
            if (otherElement.DataObjects != null && otherElement.DataObjects.Count > 0)
            {
                foreach (ValuedDataObject dataObject in otherElement.DataObjects)
                {
                    ValuedDataObject clone = (ValuedDataObject)dataObject.Clone();
                    dataObjects.Add(clone);
                    // add it to the list of FlowElements
                    // if it is already there, remove it first so order is same as
                    // data object list
                    RemoveFlowElement(clone.Id);
                    AddFlowElement(clone);
                }
            }

            flowElementList.Clear();
            foreach (FlowElement flowElement in otherElement.FlowElements)
            {
                AddFlowElement(flowElement);
            }

            artifactList.Clear();
            foreach (Artifact artifact in otherElement.Artifacts)
            {
                AddArtifact(artifact);
            }
        }

        private List<ValuedDataObject> dataObjects = new List<ValuedDataObject>();
        public List<ValuedDataObject> DataObjects
        {
            get { return dataObjects; }
            set { dataObjects = value == null ? new List<ValuedDataObject>() : value; }
        }

    }

}
