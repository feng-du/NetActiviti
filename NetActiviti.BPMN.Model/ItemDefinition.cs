using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ItemDefinition : BaseElement
    {

        private string structureRef;
        public string StructureRef
        {
            get { return structureRef; }
            set { structureRef = value; }
        }


        private string itemKind;
        public string ItemKind
        {
            get { return itemKind; }
            set { itemKind = value; }
        }



        public override BaseElement Clone()
        {
            ItemDefinition clone = new ItemDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(ItemDefinition otherElement)
        {
            base.SetValues(otherElement);
            structureRef = otherElement.StructureRef;
            itemKind = otherElement.ItemKind;
        }
    }
}
