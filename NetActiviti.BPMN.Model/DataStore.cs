using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataStore : BaseElement
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


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


        public override BaseElement Clone()
        {
            DataStore clone = new DataStore();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataStore otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            dataState = otherElement.DataState;
            itemSubjectRef = otherElement.ItemSubjectRef;
        }

    }

}
