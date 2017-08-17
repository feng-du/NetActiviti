using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class TaskWithFieldExtensions : Task
    {

        private List<FieldExtension> fieldExtensions = new List<FieldExtension>();

        public List<FieldExtension> FieldExtensions
        {
            get { return fieldExtensions; }
            set { fieldExtensions = value == null ? new List<FieldExtension>() : value; }
        }

    }

}
