using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataObject : FlowElement
    {

        private ItemDefinition itemSubjectRef;

        public ItemDefinition ItemSubjectRef
        {
            get { return itemSubjectRef; }
            set { itemSubjectRef = value; }
        }


        public override BaseElement Clone()
        {
            DataObject clone = new DataObject();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataObject otherElement)
        {
            base.SetValues(otherElement);

            Id = otherElement.Id;
            Name = otherElement.Name;
            itemSubjectRef = otherElement.ItemSubjectRef;
        }
    }
}
