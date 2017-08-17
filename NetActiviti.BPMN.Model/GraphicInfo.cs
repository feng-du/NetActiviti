using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class GraphicInfo
    {

        private double x;
        private double y;
        private double height;
        private double width;
        private BaseElement element;
        private bool expanded;
        private int xmlRowNumber;
        private int xmlColumnNumber;

        public double X
        {
            get { return x; }
            set { x = value; }
        }


        public double Y
        {
            get { return y; }
            set { y = value; }
        }


        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        public bool Expanded
        {
            get { return expanded; }
            set { expanded = value; }
        }


        public BaseElement Element
        {
            get { return element; }
            set { element = value; }
        }


        public int XmlRowNumber
        {
            get { return xmlRowNumber; }
            set { xmlRowNumber = value; }
        }


        public int XmlColumnNumber
        {
            get { return xmlColumnNumber; }
            set { xmlColumnNumber = value; }
        }

    }
}
