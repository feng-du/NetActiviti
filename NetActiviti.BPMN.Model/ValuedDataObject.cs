using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class ValuedDataObject : DataObject
    {

        protected Object value;

        public Object GetValue()
        {
            return value;
        }

        public abstract void SetValue(Object value);

        //public abstract ValuedDataObject Clone();

        public void SetValues(ValuedDataObject otherElement)
        {
            base.SetValues(otherElement);
            if (otherElement.GetValue() != null)
            {
                SetValue(otherElement.GetValue());
            }
        }

        /// <summary>
        /// origin: GetType() 
        /// </summary>
        /// <returns></returns>
        public string GetTypeDefinition()
        {
            string structureRef = ItemSubjectRef.StructureRef;
            return structureRef.Substring(structureRef.IndexOf(':') + 1);
        }


        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            ValuedDataObject otherObject = (ValuedDataObject)o;

            if (!otherObject.ItemSubjectRef.StructureRef.Equals(this.ItemSubjectRef.StructureRef))
            {
                return false;
            }
            if (!otherObject.Id.Equals(this.Id))
            {
                return false;
            }
            if (!otherObject.Name.Equals(this.Name))
            {
                return false;
            }
            if (otherObject.GetValue() == null || this.value == null || (!otherObject.GetValue().Equals(this.value.ToString())))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = (ItemSubjectRef.StructureRef + Id + Name + value == null ? "" : value.ToString()).GetHashCode();

            return hashCode;
        }
    }

}
