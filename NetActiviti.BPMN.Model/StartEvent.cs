using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class StartEvent : Event
    {

        private string initiator;
        private string formKey;
        private bool isInterrupting;
        private List<FormProperty> formProperties = new List<FormProperty>();

        public string Initiator
        {
            get { return initiator; }
            set { initiator = value; }
        }


        public string FormKey
        {
            get { return formKey; }
            set { formKey = value; }
        }


        public bool IsInterrupting
        {
            get { return isInterrupting; }
            set { IsInterrupting = value; }
        }


        public List<FormProperty> FormProperties
        {
            get { return formProperties; }
            set { formProperties = value; }
        }


        public override BaseElement Clone()
        {
            StartEvent clone = new StartEvent();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(StartEvent otherEvent)
        {
            base.SetValues(otherEvent);
            initiator = otherEvent.Initiator;
            formKey = otherEvent.FormKey;
            isInterrupting = otherEvent.IsInterrupting;

            formProperties = new List<FormProperty>();
            if (otherEvent.FormProperties != null && otherEvent.FormProperties.Count > 0)
            {
                foreach (FormProperty property in otherEvent.FormProperties)
                {
                    formProperties.Add((FormProperty)property.Clone());
                }
            }
        }
    }
}
