using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataStoreReference : FlowElement
    {

        private string dataState;
        public string DataState
        {
            get { return dataState; }
            set { dataState = value; }
        }

        private string itemSubjectRef;
        public string ItemSubjectRef
        {
            get { return itemSubjectRef; }
            set { itemSubjectRef = value; }
        }

        private string dataStoreRef;
        public string DataStoreRef
        {
            get { return dataStoreRef; }
            set { dataStoreRef = value; }
        }


        public override BaseElement Clone()
        {
            DataStoreReference clone = new DataStoreReference();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataStoreReference otherElement)
        {
            base.SetValues(otherElement);
            dataState = otherElement.DataState;
            itemSubjectRef = otherElement.ItemSubjectRef;
            dataStoreRef = otherElement.DataStoreRef;
        }

    }
}
