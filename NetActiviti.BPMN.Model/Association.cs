using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class Association : Artifact
    {

        private AssociationDirection associationDirection = AssociationDirection.NONE;
        public AssociationDirection AssociationDirection
        {
            get { return associationDirection; }
            set { associationDirection = value; }
        }


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


        public override BaseElement Clone()
        {
            Association clone = new Association();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(Association otherElement)
        {
            base.SetValues(otherElement);
            sourceRef = otherElement.SourceRef;
            targetRef = otherElement.TargetRef;

            if (otherElement.AssociationDirection != null)
            {
                associationDirection = otherElement.AssociationDirection;
            }
        }
    }
}
