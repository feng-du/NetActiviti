using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class AssociationModel
    {

        public string id;
        public AssociationDirection associationDirection;
        public string sourceRef;
        public string targetRef;
        public Process parentProcess;
    }
}
