using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class DataAssociation : BaseElement
    {

        private string sourceRef;
        public string SourceRef
        {
            get { return sourceRef; }
            set { sourceRef = value; }
        }

        private string targetRef;
        public string TargetRef
        {
            get { return targetRef; }
            set { targetRef = value; }
        }


        private string transformation;
        public string Transformation
        {
            get { return transformation; }
            set { transformation = value; }
        }


        private List<Assignment> assignments = new List<Assignment>();
        public List<Assignment> Assignments
        {
            get { return assignments; }
            set { assignments = value; }
        }



        public override BaseElement Clone()
        {
            DataAssociation clone = new DataAssociation();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(DataAssociation otherAssociation)
        {
            sourceRef = otherAssociation.SourceRef;
            targetRef = otherAssociation.TargetRef;
            transformation = otherAssociation.Transformation;

            assignments = new List<Assignment>();
            if (otherAssociation.Assignments != null && otherAssociation.Assignments.Count > 0)
            {
                foreach (Assignment assignment in otherAssociation.Assignments)
                {
                    assignments.Add((Assignment)assignment.Clone());
                }
            }
        }
    }
}
