using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataSpec : BaseElement
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string itemSubjectRef;
        public string ItemSubjectRef
        {
            get { return itemSubjectRef; }
            set { itemSubjectRef = value; }
        }


        private bool isCollection;
        public bool IsCollection
        {
            get { return isCollection; }
            set { isCollection = value; }
        }



        public override BaseElement Clone()
        {
            DataSpec clone = new DataSpec();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataSpec otherDataSpec)
        {
            name = otherDataSpec.Name;
            itemSubjectRef = otherDataSpec.ItemSubjectRef;
            isCollection = otherDataSpec.IsCollection;
        }
    }
}
