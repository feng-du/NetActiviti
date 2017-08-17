using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Message : BaseElement
    {

        private string name;
        private string itemRef;

        public Message()
        {
        }

        public Message(string id, string name, string itemRef)
        {
            this.Id = id;
            this.name = name;
            this.itemRef = itemRef;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ItemRef
        {
            get { return itemRef; }
            set { ItemRef = value; }
        }


        public override BaseElement Clone()
        {
            Message clone = new Message();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Message otherElement)
        {
            base.SetValues(otherElement);
            name = otherElement.Name;
            itemRef = otherElement.ItemRef;
        }
    }
}
