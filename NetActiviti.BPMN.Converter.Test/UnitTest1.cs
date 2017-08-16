using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;

namespace NetActiviti.BPMN.Converter.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var path = System.Environment.CurrentDirectory + @"\Resource\";

            var serialzer = new XmlSerializer(typeof(tDefinitions));
            var XmlStream = new StreamReader( path +"bpmn.xml");
            var document = (tDefinitions)serialzer.Deserialize(XmlStream);
        }
    }
}
