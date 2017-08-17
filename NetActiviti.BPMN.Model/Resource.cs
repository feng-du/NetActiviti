using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    /**
     * The Resource class is used to specify resources that can be referenced by
     * Activities. These Resources can be Human Resources as well as any other
     * resource assigned to Activities during Process execution time.
     *
     */
    public class Resource : BaseElement
    {

        private string name;

        public Resource(string resourceId, string resourceName)
        {

            Id = resourceId;
            name = resourceName;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override BaseElement Clone()
        {
            return new Resource(Id, Name);
        }
    }
}
