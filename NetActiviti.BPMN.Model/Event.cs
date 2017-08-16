using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{

    public abstract class Event : FlowNode
    {

        private List<EventDefinition> eventDefinitions = new List<EventDefinition>();

        public List<EventDefinition> EventDefinitions
        {
            get { return eventDefinitions; }
            set { eventDefinitions = value == null ? new List<EventDefinition>() : value; }
        }



        public void AddEventDefinition(EventDefinition eventDefinition)
        {
            eventDefinitions.Add(eventDefinition);
        }

        public void SetValues(Event otherEvent)
        {
            base.SetValues(otherEvent);

            eventDefinitions = new List<EventDefinition>();
            if (otherEvent.EventDefinitions != null && otherEvent.EventDefinitions.Count > 0)
            {
                foreach (EventDefinition eventDef in otherEvent.EventDefinitions)
                {
                    eventDefinitions.Add((EventDefinition)eventDef.Clone());
                }
            }
        }
    }
}
