using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetActiviti.Common.Extensions;
using Newtonsoft.Json;

namespace NetActiviti.BPMN.Model
{
    public class BpmnModel
    {

        protected Dictionary<string, List<ExtensionAttribute>> definitionsAttributes = new Dictionary<string, List<ExtensionAttribute>>();
        protected List<Process> processes = new List<Process>();
        protected Dictionary<string, GraphicInfo> locationMap = new Dictionary<string, GraphicInfo>();
        protected Dictionary<string, GraphicInfo> labelLocationMap = new Dictionary<string, GraphicInfo>();
        protected Dictionary<string, List<GraphicInfo>> flowLocationMap = new Dictionary<string, List<GraphicInfo>>();
        protected List<Signal> signals = new List<Signal>();
        protected Dictionary<string, MessageFlow> messageFlowMap = new Dictionary<string, MessageFlow>();
        protected Dictionary<string, Message> messageMap = new Dictionary<string, Message>();
        protected Dictionary<string, string> errorMap = new Dictionary<string, string>();
        protected Dictionary<string, ItemDefinition> itemDefinitionMap = new Dictionary<string, ItemDefinition>();
        protected Dictionary<string, DataStore> dataStoreMap = new Dictionary<string, DataStore>();
        protected List<Pool> pools = new List<Pool>();
        protected List<Import> imports = new List<Import>();
        protected List<Interface> interfaces = new List<Interface>();
        protected List<Artifact> globalArtifacts = new List<Artifact>();
        protected List<Resource> resources = new List<Resource>();
        protected Dictionary<string, string> namespaceMap = new Dictionary<string, string>();
        protected string targetNamespace;
        protected string sourceSystemId;
        protected List<string> userTaskFormTypes;
        protected List<string> startEventFormTypes;
        protected int nextFlowIdCounter = 1;
        protected Object eventSupport;

        public Dictionary<string, List<ExtensionAttribute>> DefinitionsAttributes
        {
            get { return definitionsAttributes; }
            set { definitionsAttributes = value; }
        }

        public string GetDefinitionsAttributeValue(string _namespace, string name) {
            List<ExtensionAttribute> attributes = DefinitionsAttributes.Get(name);
            if (!attributes.IsNullOrEmpty()) {
                foreach (ExtensionAttribute attribute in attributes) {
                    if (_namespace == attribute.NameSpace)
                        return attribute.Value;
                }
            }
            return null;
        }

        public void AddDefinitionsAttribute(ExtensionAttribute attribute)
        {
            if (attribute != null && (!string.IsNullOrEmpty(attribute.Name)))
            {
                List<ExtensionAttribute> attributeList = null;
                if (!this.definitionsAttributes.ContainsKey(attribute.Name))
                {
                    attributeList = new List<ExtensionAttribute>();
                    this.definitionsAttributes.Add(attribute.Name, attributeList);
                }
                this.definitionsAttributes[attribute.Name].Add(attribute);
            }
        }

        public Process GetMainProcess()
        {
            if (!Pools.IsNullOrEmpty())
            {
                return GetProcess(Pools.First().Id);
            }
            else
            {
                return GetProcess(null);
            }
        }

        public Process GetProcess(string poolRef)
        {
            foreach (Process process in processes)
            {
                bool foundPool = false;
                foreach (Pool pool in pools)
                {
                    if ((!string.IsNullOrEmpty(pool.ProcessRef)) && pool.ProcessRef.EqualsIgnoreCase(process.Id))
                    {

                        if (poolRef != null)
                        {
                            if (pool.Id.EqualsIgnoreCase(poolRef))
                            {
                                foundPool = true;
                            }
                        }
                        else
                        {
                            foundPool = true;
                        }
                    }
                }

                if (poolRef == null && !foundPool)
                {
                    return process;
                }
                else if (poolRef != null && foundPool)
                {
                    return process;
                }
            }

            return null;
        }

        public Process GetProcessById(string id)
        {
            foreach (Process process in processes)
            {
                if (process.Id == id)
                {
                    return process;
                }
            }
            return null;
        }

        public List<Process> Processes
        {
            get { return processes; }
        }

        public void AddProcess(Process process)
        {
            processes.Add(process);
        }

        public Pool GetPool(string id)
        {
            Pool foundPool = null;
            if (!string.IsNullOrEmpty(id))
            {
                foreach (Pool pool in pools)
                {
                    if (id == pool.Id)
                    {
                        foundPool = pool;
                        break;
                    }
                }
            }
            return foundPool;
        }

        public Lane GetLane(string id)
        {
            Lane foundLane = null;
            if (!string.IsNullOrEmpty(id))
            {
                foreach (Process process in processes)
                {
                    foreach (Lane lane in process.Lanes)
                    {
                        if (id == lane.Id)
                        {
                            foundLane = lane;
                            break;
                        }
                    }
                    if (foundLane != null)
                    {
                        break;
                    }
                }
            }
            return foundLane;
        }

        public FlowElement GetFlowElement(string id)
        {
            FlowElement foundFlowElement = null;
            foreach (Process process in processes)
            {
                foundFlowElement = process.GetFlowElement(id);
                if (foundFlowElement != null)
                {
                    break;
                }
            }

            if (foundFlowElement == null)
            {
                foreach (Process process in processes)
                {
                    foreach (FlowElement flowElement in process.FindFlowElementsOfType<SubProcess>()) {
                        foundFlowElement = GetFlowElementInSubProcess(id, (SubProcess)flowElement);
                        if (foundFlowElement != null) {
                            break;
                        }
                    }
                    if (foundFlowElement != null) {
                        break;
                    }
                }
            }

            return foundFlowElement;
        }

        protected FlowElement GetFlowElementInSubProcess(string id, SubProcess subProcess)
        {
            FlowElement foundFlowElement = subProcess.GetFlowElement(id);
            if (foundFlowElement == null)
            {
                foreach (FlowElement flowElement in subProcess.GetFlowElements())
                {
                    if (flowElement is SubProcess) {
                        foundFlowElement = GetFlowElementInSubProcess(id, (SubProcess)flowElement);
                        if (foundFlowElement != null)
                        {
                            break;
                        }
                    }
                }
            }
            return foundFlowElement;
        }

        public Artifact GetArtifact(string id)
        {
            Artifact foundArtifact = null;
            foreach (Process process in processes)
            {
                foundArtifact = process.GetArtifact(id);
                if (foundArtifact != null)
                {
                    break;
                }
            }

            if (foundArtifact == null)
            {
                foreach (Process process in processes)
                {
                    foreach (FlowElement flowElement in process.FindFlowElementsOfType<SubProcess>()) {
                        foundArtifact = GetArtifactInSubProcess(id, (SubProcess)flowElement);
                        if (foundArtifact != null) {
                            break;
                        }
                    }
                    if (foundArtifact != null) {
                        break;
                    }
                }
            }

            return foundArtifact;
        }

        protected Artifact GetArtifactInSubProcess(string id, SubProcess subProcess)
        {
            Artifact foundArtifact = subProcess.GetArtifact(id);
            if (foundArtifact == null)
            {
                foreach (FlowElement flowElement in subProcess.GetFlowElements())
                {
                    if (flowElement is SubProcess) {
                        foundArtifact = GetArtifactInSubProcess(id, (SubProcess)flowElement);
                        if (foundArtifact != null)
                        {
                            break;
                        }
                    }
                }
            }
            return foundArtifact;
        }

        public void AddGraphicInfo(string key, GraphicInfo graphicInfo)
        {
            locationMap.Add(key, graphicInfo);
        }

        public GraphicInfo GetGraphicInfo(string key)
        {
            return locationMap.Get(key);
        }

        public void RemoveGraphicInfo(string key)
        {
            locationMap.Remove(key);
        }

        public List<GraphicInfo> GetFlowLocationGraphicInfo(string key)
        {
            return flowLocationMap.Get(key);
        }

        public void RemoveFlowGraphicInfoList(string key)
        {
            flowLocationMap.Remove(key);
        }

        public Dictionary<string, GraphicInfo> LocationMap
        {
            get { return locationMap; }
        }

        public Dictionary<string, List<GraphicInfo>> FlowLocationMap
        {
            get { return flowLocationMap; }
        }

        public GraphicInfo GetLabelGraphicInfo(string key)
        {
            return labelLocationMap.Get(key);
        }

        public void AddLabelGraphicInfo(string key, GraphicInfo graphicInfo)
        {
            labelLocationMap.Add(key, graphicInfo);
        }

        public void RemoveLabelGraphicInfo(string key)
        {
            labelLocationMap.Remove(key);
        }

        public Dictionary<string, GraphicInfo> LabelLocationMap
        {
            get { return labelLocationMap; }
        }

        public void AddFlowGraphicInfoList(string key, List<GraphicInfo> graphicInfoList)
        {
            flowLocationMap.Add(key, graphicInfoList);
        }

        public List<Resource> Resources
        {
            get { return resources; }
            set { resources = value == null ? new List<Resource>() : value; }
        }


        public void AddResource(Resource resource)
        {
            if (resource != null)
            {
                resources.Add(resource);
            }
        }

        public bool ContainsResourceId(string resourceId)
        {
            return GetResource(resourceId) != null;
        }

        public Resource GetResource(string id)
        {
            foreach (Resource resource in resources)
            {
                if (id == resource.Id)
                {
                    return resource;
                }
            }
            return null;
        }

        public List<Signal> Signals
        {
            get { return signals; }
            set { signals = value == null ? new List<Signal>() : value; }
        }


        public void AddSignal(Signal signal)
        {
            if (signal != null)
            {
                signals.Add(signal);
            }
        }

        public bool ContainsSignalId(string signalId)
        {
            return GetSignal(signalId) != null;
        }

        public Signal GetSignal(string id)
        {
            foreach (Signal signal in signals)
            {
                if (id == signal.Id)
                {
                    return signal;
                }
            }
            return null;
        }

        public Dictionary<string, MessageFlow> MessageFlows
        {
            get { return messageFlowMap; }
            set { messageFlowMap = value == null ? new Dictionary<string, MessageFlow>() : value; }
        }


        public void AddMessageFlow(MessageFlow messageFlow)
        {
            if (messageFlow != null && (!string.IsNullOrEmpty(messageFlow.Id)))
            {
                messageFlowMap.Add(messageFlow.Id, messageFlow);
            }
        }

        public MessageFlow GetMessageFlow(string id)
        {
            return messageFlowMap.Get(id);
        }

        public bool ContainsMessageFlowId(string messageFlowId)
        {
            return messageFlowMap.ContainsKey(messageFlowId);
        }

        public List<Message> Messages
        {
            get { return messageMap.Values.ToList(); }
            set
            {
                if (value != null)
                {
                    messageMap.Clear();
                    foreach (Message message in value)
                    {
                        AddMessage(message);
                    }
                }
            }
        }


        public void AddMessage(Message message)
        {
            if (message != null && (!string.IsNullOrEmpty(message.Id)))
            {
                messageMap.Add(message.Id, message);
            }
        }

        public Message GetMessage(string id)
        {
            Message result = messageMap.Get(id);
            if (result == null)
            {
                int indexOfNS = id.IndexOf(":");
                if (indexOfNS > 0)
                {
                    string idNamespace = id.Substring(0, indexOfNS);
                    if (idNamespace.EqualsIgnoreCase(this.TargetNamespace))
                    {
                        id = id.Substring(indexOfNS + 1);
                    }
                    result = messageMap.Get(id);
                }
            }
            return result;
        }

        public bool ContainsMessageId(string messageId)
        {
            return messageMap.ContainsKey(messageId);
        }

        public Dictionary<string, string> Errors
        {
            get { return errorMap; }
            set { errorMap = value == null ? new Dictionary<string, string>() : value; }
        }


        public void AddError(string errorRef, string errorCode)
        {
            if (!string.IsNullOrEmpty(errorRef))
            {
                errorMap.Add(errorRef, errorCode);
            }
        }

        public bool ContainsErrorRef(string errorRef)
        {
            return errorMap.ContainsKey(errorRef);
        }

        public Dictionary<string, ItemDefinition> ItemDefinitions
        {
            get { return itemDefinitionMap; }
            set { itemDefinitionMap = value == null ? new Dictionary<string, ItemDefinition>() : value; }
        }



        public void AddItemDefinition(string id, ItemDefinition item)
        {
            if (!string.IsNullOrEmpty(id))
            {
                itemDefinitionMap.Add(id, item);
            }
        }

        public bool ContainsItemDefinitionId(string id)
        {
            return itemDefinitionMap.ContainsKey(id);
        }

        public Dictionary<string, DataStore> DataStores
        {
            get { return dataStoreMap; }
            set { dataStoreMap = value == null ? new Dictionary<string, DataStore>() : value; }
        }



        public DataStore GetDataStore(string id)
        {
            DataStore dataStore = null;
            if (dataStoreMap.ContainsKey(id))
            {
                dataStore = dataStoreMap.Get(id);
            }
            return dataStore;
        }

        public void AddDataStore(string id, DataStore dataStore)
        {
            if (!string.IsNullOrEmpty(id))
            {
                dataStoreMap.Add(id, dataStore);
            }
        }

        public bool ContainsDataStore(string id)
        {
            return dataStoreMap.ContainsKey(id);
        }

        public List<Pool> Pools
        {
            get { return pools; }
            set { pools = value == null ? new List<Pool>() : value; }
        }


        public List<Import> Imports
        {
            get { return imports; }
            set { imports = value == null ? new List<Import>() : value; }
        }


        public List<Interface> Interfaces
        {
            get { return interfaces; }
            set { interfaces = value == null ? new List<Interface>() : value; }
        }


        public List<Artifact> GlobalArtifacts
        {
            get { return globalArtifacts; }
            set { globalArtifacts = value == null ? new List<Artifact>() : value; }
        }


        public void AddNamespace(string prefix, string uri)
        {
            namespaceMap.Add(prefix, uri);
        }

        public bool ContainsNamespacePrefix(string prefix)
        {
            return namespaceMap.ContainsKey(prefix);
        }

        public string GetNamespace(string prefix)
        {
            return namespaceMap.Get(prefix);
        }

        public Dictionary<string, string> Namespaces
        {
            get { return namespaceMap; }
            set { namespaceMap = value == null ? new Dictionary<string, string>() : value; }
        }

        public string TargetNamespace
        {
            get { return targetNamespace; }
            set { targetNamespace = value; }
        }


        public string SourceSystemId
        {
            get { return sourceSystemId; }
            set { sourceSystemId = value; }
        }


        public List<string> UserTaskFormTypes
        {
            get { return userTaskFormTypes; }
            set { userTaskFormTypes = value == null ? new List<string>() : value; }
        }


        public List<string> StartEventFormTypes
        {
            get { return startEventFormTypes; }
            set { startEventFormTypes = value == null ? new List<string>() : value; }
        }



        [JsonIgnore]
        public Object EventSupport
        {
            get { return eventSupport; }
            set { eventSupport = value; }
        }

    }

}
