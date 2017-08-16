using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataGridRow
    {

        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        private List<DataGridField> fields = new List<DataGridField>();
        public List<DataGridField> Fields
        {
            get { return fields; }
            set { fields = value == null ? new List<DataGridField>() : value; }
        }

        public DataGridRow Clone()
        {
            DataGridRow clone = new DataGridRow();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataGridRow otherRow)
        {
            index = otherRow.Index;

            fields = new List<DataGridField>();
            if (otherRow.Fields != null && otherRow.Fields.Count > 0)
            {
                foreach (DataGridField field in otherRow.Fields)
                {
                    fields.Add((DataGridField)field.Clone());
                }
            }
        }
    }
}
