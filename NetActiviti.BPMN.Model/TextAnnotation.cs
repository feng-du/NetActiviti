using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class TextAnnotation : Artifact
    {

        private string text;
        private string textFormat;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        public string TextFormat
        {
            get { return textFormat; }
            set { textFormat = value; }
        }


        public override BaseElement Clone()
        {
            TextAnnotation clone = new TextAnnotation();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(TextAnnotation otherElement)
        {
            base.SetValues(otherElement);
            text = otherElement.Text;
            textFormat = otherElement.TextFormat;
        }
    }
}
