using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class IOSpecification : BaseElement
    {

        private List<DataSpec> dataInputs = new List<DataSpec>();
        public List<DataSpec> DataInputs
        {
            get { return dataInputs; }
            set { dataInputs = value == null ? new List<DataSpec>() : value; }
        }

        private List<DataSpec> dataOutputs = new List<DataSpec>();
        public List<DataSpec> DataOutputs
        {
            get { return dataOutputs; }
            set { dataOutputs = value == null ? new List<DataSpec>() : value; }
        }


        private List<string> dataInputRefs = new List<string>();
        public List<string> DataInputRefs
        {
            get { return dataInputRefs; }
            set { dataInputRefs = value == null ? new List<string>() : value; }
        }


        private List<string> dataOutputRefs = new List<string>();
        public List<string> DataOutputRefs
        {
            get { return dataOutputRefs; }
            set { dataOutputRefs = value == null ? new List<string>() : value; }
        }


        public override BaseElement Clone()
        {
            IOSpecification clone = new IOSpecification();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(IOSpecification otherSpec)
        {
            dataInputs = new List<DataSpec>();
            if (otherSpec.DataInputs != null && otherSpec.DataInputs.Count > 0)
            {
                foreach (DataSpec dataSpec in otherSpec.DataInputs)
                {
                    dataInputs.Add((DataSpec)dataSpec.Clone());
                }
            }

            dataOutputs = new List<DataSpec>();
            if (otherSpec.DataOutputs != null && otherSpec.DataOutputs.Count > 0)
            {
                foreach (DataSpec dataSpec in otherSpec.DataOutputs)
                {
                    dataOutputs.Add((DataSpec)dataSpec.Clone());
                }
            }

            dataInputRefs = new List<string>(otherSpec.DataInputRefs);
            dataOutputRefs = new List<string>(otherSpec.DataOutputRefs);
        }
    }

}
