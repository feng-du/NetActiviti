using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataGrid : IComplexDataType
    {
        private List<DataGridRow> rows = new List<DataGridRow>();
        public List<DataGridRow> Rows
        {
            get { return rows; }
            set { rows = value == null ? new List<DataGridRow>() : value; }
        }


        public DataGrid Clone()
        {
            DataGrid clone = new DataGrid();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataGrid otherGrid)
        {
            rows = new List<DataGridRow>();
            if (otherGrid.Rows != null && otherGrid.Rows.Count > 0)
            {
                foreach (DataGridRow row in otherGrid.Rows)
                {
                    rows.Add(row.Clone());
                }
            }
        }
    }
}
