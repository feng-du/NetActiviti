using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class EventListener : BaseElement
    {

        private string events;
        public string Events
        {
            get { return events; }
            set { events = value; }
        }

        private string implementationType;
        public string ImplementationType
        {
            get { return implementationType; }
            set { implementationType = value; }
        }


        private string implementation;
        public string Implementation
        {
            get { return implementation; }
            set { implementation = value; }
        }

        private string entityType;
        public string EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public override BaseElement Clone()
        {
            EventListener clone = new EventListener();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(EventListener otherListener)
        {
            events = otherListener.Events;
            implementation = otherListener.Implementation;
            implementationType = otherListener.ImplementationType;
            entityType = otherListener.EntityType;
        }
    }
}
