using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ActivitiListener : BaseElement
    {
        private string _event;
        public string Event
        {
            get { return _event; }
            set { _event = value; }
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

        private List<FieldExtension> fieldExtensions = new List<FieldExtension>();
        public List<FieldExtension> FieldExtensions
        {
            get { return fieldExtensions; }
            set { fieldExtensions = value == null ? new List<FieldExtension>() : value; }
        }

        private string onTransaction;
        public string OnTransaction
        {
            get { return onTransaction; }
            set { onTransaction = value; }
        }

        private string customPropertiesResolverImplementationType;
        public string CustomPropertiesResolverImplementationType
        {
            get { return customPropertiesResolverImplementationType; }
            set { customPropertiesResolverImplementationType = value; }
        }

        private string customPropertiesResolverImplementation;
        public string CustomPropertiesResolverImplementation
        {
            get { return customPropertiesResolverImplementation; }
            set { customPropertiesResolverImplementation = value; }
        }

        // Can be used to set an instance of the listener directly. That instance will then always be reused.
        private object instance;
        [JsonIgnore]
        public object Instance
        {
            get { return instance; }
            set { instance = value; }
        }


        public override BaseElement Clone()
        {
            ActivitiListener clone = new ActivitiListener();
            clone.SetValues(this);
            return clone;
        }


        public void SetValues(ActivitiListener otherListener)
        {

            _event = otherListener.Event;
            implementation = otherListener.Implementation;
            implementationType = otherListener.ImplementationType;

            fieldExtensions = new List<FieldExtension>();
            if (otherListener.FieldExtensions != null && otherListener.FieldExtensions.Count > 0)
            {
                foreach (FieldExtension extension in otherListener.FieldExtensions)
                {
                    fieldExtensions.Add((FieldExtension)extension.Clone());
                }
            }
        }

    }
}
