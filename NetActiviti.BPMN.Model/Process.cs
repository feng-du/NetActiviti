using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Process : BaseElement, IFlowElementsContainer, IHasExecutionListeners
    {
        private string name;
        private bool executable = true;
        private string documentation;
        private IOSpecification ioSpecification;
        private List<ActivitiListener> executionListeners = new List<ActivitiListener>();
        private List<Lane> lanes = new List<Lane>();
        private List<FlowElement> flowElementList = new List<FlowElement>();
        private List<ValuedDataObject> dataObjects = new List<ValuedDataObject>();
        private List<Artifact> artifactList = new List<Artifact>();
        private List<string> candidateStarterUsers = new List<string>();
        private List<string> candidateStarterGroups = new List<string>();
        private List<EventListener> eventListeners = new List<EventListener>();
        private Dictionary<string, FlowElement> flowElementMap = new Dictionary<string, FlowElement>();

        // Added during process definition parsing
        private FlowElement initialFlowElement;

        public Process()
        {

        }

        public string Documentation
        {
            get { return documentation; }
            set { documentation = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public bool IsExecutable
        {
            get { return executable; }
            set { executable = value; }
        }


        public IOSpecification IoSpecification
        {
            get { return ioSpecification; }
            set { ioSpecification = value; }
        }


        public List<ActivitiListener> GetExecutionListeners()
        {
            return executionListeners;
        }

        public void SetExecutionListeners(List<ActivitiListener> executionListeners)
        {
            this.executionListeners = executionListeners;
        }

        public List<Lane> Lanes
        {
            get { return lanes; }
            set { lanes = value == null ? new List<Lane>() : value; }
        }


        public Dictionary<string, FlowElement> FlowElementMap
        {
            get { return flowElementMap; }
            set { flowElementMap = value == null ? new Dictionary<string, FlowElement>() : value; }
        }


        public bool ContainsFlowElementId(string id)
        {
            return flowElementMap.ContainsKey(id);
        }

        public FlowElement GetFlowElement(string flowElementId)
        {
            return GetFlowElement(flowElementId, false);
        }

        /**
         * @param searchRecurive: searches the whole process, including subprocesses
         */
        public FlowElement GetFlowElement(string flowElementId, bool searchRecurive)
        {
            if (searchRecurive)
            {
                return flowElementMap[flowElementId];
            }
            else
            {
                return FindFlowElementInList(flowElementId);
            }
        }

        public List<Association> FindAssociationsWithSourceRefRecursive(string sourceRef)
        {
            return FindAssociationsWithSourceRefRecursive(this, sourceRef);
        }

        private List<Association> FindAssociationsWithSourceRefRecursive(IFlowElementsContainer flowElementsContainer, string sourceRef)
        {
            List<Association> associations = new List<Association>();
            foreach (Artifact artifact in flowElementsContainer.GetArtifacts())
            {
                if (artifact is Association)
                {
                    Association association = (Association)artifact;
                    if (association.SourceRef != null && association.TargetRef != null && association.SourceRef == sourceRef)
                    {
                        associations.Add(association);
                    }
                }
            }

            foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
            {
                if (flowElement is IFlowElementsContainer)
                {
                    associations.AddRange(FindAssociationsWithSourceRefRecursive((IFlowElementsContainer)flowElement, sourceRef));
                }
            }
            return associations;
        }

        public List<Association> FindAssociationsWithTargetRefRecursive(string targetRef)
        {
            return FindAssociationsWithTargetRefRecursive(this, targetRef);
        }

        private List<Association> FindAssociationsWithTargetRefRecursive(IFlowElementsContainer flowElementsContainer, string targetRef)
        {
            List<Association> associations = new List<Association>();
            foreach (Artifact artifact in flowElementsContainer.GetArtifacts())
            {
                if (artifact is Association)
                {
                    Association association = (Association)artifact;
                    if (association.TargetRef != null && association.TargetRef == targetRef)
                    {
                        associations.Add(association);
                    }
                }
            }

            foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
            {
                if (flowElement is IFlowElementsContainer)
                {
                    associations.AddRange(FindAssociationsWithTargetRefRecursive((IFlowElementsContainer)flowElement, targetRef));
                }
            }
            return associations;
        }

        /**
         * Searches the whole process, including subprocesses
         */
        public IFlowElementsContainer GetFlowElementsContainer(string flowElementId)
        {
            return GetFlowElementsContainer(this, flowElementId);
        }

        private IFlowElementsContainer GetFlowElementsContainer(IFlowElementsContainer flowElementsContainer, string flowElementId)
        {
            foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
            {
                if (flowElement.Id != null && flowElement.Id == flowElementId)
                {
                    return flowElementsContainer;
                }
                else if (flowElement is IFlowElementsContainer)
                {
                    IFlowElementsContainer result = GetFlowElementsContainer((IFlowElementsContainer)flowElement, flowElementId);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        private FlowElement FindFlowElementInList(string flowElementId)
        {
            foreach (FlowElement f in flowElementList)
            {
                if (f.Id != null && f.Id == flowElementId)
                {
                    return f;
                }
            }
            return null;
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
            }
        }

        public void AddFlowElementToMap(FlowElement element)
        {
            if (element != null && (!string.IsNullOrEmpty(element.Id)))
            {
                flowElementMap.Add(element.Id, element);
            }
        }

        public void RemoveFlowElement(string elementId)
        {
            FlowElement element = flowElementMap[elementId];
            if (element != null)
            {
                flowElementList.Remove(element);
                flowElementMap.Remove(element.Id);
            }
        }

        public void RemoveFlowElementFromMap(string elementId)
        {
            if (!string.IsNullOrEmpty(elementId))
            {
                flowElementMap.Remove(elementId);
            }
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

        public List<string> CandidateStarterUsers
        {
            get { return candidateStarterUsers; }
            set { candidateStarterUsers = value == null ? new List<string>() : value; }
        }


        public List<string> CandidateStarterGroups
        {
            get { return candidateStarterGroups; }
            set { candidateStarterGroups = value == null ? new List<string>() : value; }
        }



        public List<EventListener> EventListeners
        {
            get { return eventListeners; }
            set { eventListeners = value == null ? new List<EventListener>() : value; }
        }


        public List<FlowElementType> FindFlowElementsOfType<FlowElementType>() where FlowElementType : FlowElement
        {
            return FindFlowElementsOfType<FlowElementType>(true);
        }

        public List<FlowElementType> FindFlowElementsOfType<FlowElementType>(bool goIntoSubprocesses) where FlowElementType : FlowElement
        {

            List<FlowElementType> foundFlowElements = new List<FlowElementType>();
            foreach (FlowElement flowElement in this.GetFlowElements())
            {
                if (flowElement.GetType() == typeof(FlowElementType))
                {
                    foundFlowElements.Add((FlowElementType)flowElement);
                }
                if (flowElement is SubProcess)
                {
                    if (goIntoSubprocesses)
                    {
                        foundFlowElements.AddRange(FindFlowElementsInSubProcessOfType<FlowElementType>((SubProcess)flowElement));
                    }
                }
            }
            return foundFlowElements;
        }

        public List<FlowElementType> FindFlowElementsInSubProcessOfType<FlowElementType>(SubProcess subProcess) where FlowElementType : FlowElement
        {
            return FindFlowElementsInSubProcessOfType<FlowElementType>(subProcess, true);
        }

        public List<FlowElementType> FindFlowElementsInSubProcessOfType<FlowElementType>(SubProcess subProcess, bool goIntoSubprocesses) where FlowElementType : FlowElement
        {

            List<FlowElementType> foundFlowElements = new List<FlowElementType>();
            foreach (FlowElement flowElement in subProcess.GetFlowElements())
            {
                if (flowElement.GetType() == typeof(FlowElementType))
                {
                    foundFlowElements.Add((FlowElementType)flowElement);
                }
                if (flowElement is SubProcess)
                {
                    if (goIntoSubprocesses)
                    {
                        foundFlowElements.AddRange(FindFlowElementsInSubProcessOfType<FlowElementType>((SubProcess)flowElement));
                    }
                }
            }
            return foundFlowElements;
        }

        public IFlowElementsContainer FindParent(FlowElement childElement)
        {
            return FindParent(childElement, this);
        }

        public IFlowElementsContainer FindParent(FlowElement childElement, IFlowElementsContainer flowElementsContainer)
        {
            foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
            {
                if (childElement.Id != null && childElement.Id == flowElement.Id)
                {
                    return flowElementsContainer;
                }
                if (flowElement is IFlowElementsContainer)
                {
                    IFlowElementsContainer result = FindParent(childElement, (IFlowElementsContainer)flowElement);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        public List<ValuedDataObject> DataObjects
        {
            get { return dataObjects; }
            set { dataObjects = value == null ? new List<ValuedDataObject>() : value; }
        }


        public FlowElement InitialFlowElement
        {
            get { return initialFlowElement; }
            set { initialFlowElement = value; }
        }


        public override BaseElement Clone()
        {
            Process clone = new Process();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Process otherElement)
        {
            base.SetValues(otherElement);

            //    setBpmnModel(bpmnModel);
            name = otherElement.Name;
            executable = otherElement.IsExecutable;
            documentation = otherElement.Documentation;
            if (otherElement.IoSpecification != null)
            {
                ioSpecification = (IOSpecification)otherElement.IoSpecification.Clone();
            }

            executionListeners = new List<ActivitiListener>();
            if (otherElement.GetExecutionListeners() != null && otherElement.GetExecutionListeners().Count > 0)
            {
                foreach (ActivitiListener listener in otherElement.GetExecutionListeners())
                {
                    executionListeners.Add((ActivitiListener)listener.Clone());
                }
            }

            candidateStarterUsers = new List<string>();
            if (otherElement.CandidateStarterUsers != null && otherElement.CandidateStarterUsers.Count > 0)
            {
                candidateStarterUsers.AddRange(otherElement.CandidateStarterUsers);
            }

            candidateStarterGroups = new List<string>();
            if (otherElement.CandidateStarterGroups != null && otherElement.CandidateStarterGroups.Count > 0)
            {
                candidateStarterGroups.AddRange(otherElement.CandidateStarterGroups);
            }

            eventListeners = new List<EventListener>();
            if (otherElement.EventListeners != null && otherElement.EventListeners.Count > 0)
            {
                foreach (EventListener listener in otherElement.EventListeners)
                {
                    eventListeners.Add((EventListener)listener.Clone());
                }
            }

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
        }



    }

}
