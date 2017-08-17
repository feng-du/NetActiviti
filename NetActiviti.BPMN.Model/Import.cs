using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Import : BaseElement
    {

        private string importType;
        private string location;
        private string _namespace;

        public string ImportType
        {
            get { return importType; }
            set { importType = value; }
        }


        public string Location
        {
            get { return location; }
            set { location = value; }
        }


        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }


        public override BaseElement Clone()
        {
            Import clone = new Import();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Import otherElement)
        {
            base.SetValues(otherElement);
            importType = otherElement.ImportType;
            location = otherElement.Location;
            _namespace = otherElement.Namespace;
        }
    }
}
