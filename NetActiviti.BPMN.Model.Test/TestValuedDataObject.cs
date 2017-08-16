using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetActiviti.BPMN.Model.Test
{
    [TestClass]
    public class TestValuedDataObject
    {
        [TestMethod]
        public void Test_Equals()
        {
            var obj = new MockValuedDataObject()
            {
                ItemSubjectRef = new ItemDefinition { StructureRef = "test" },
                Id = "5",
                Name = "jack",
            
            };
            obj.SetValue("omd");

            var obj2 = new MockValuedDataObject()
            {
                ItemSubjectRef = new ItemDefinition { StructureRef = "test" },
                Id = "5",
                Name = "jack",

            };
            obj.SetValue("omd");
            obj2.SetValue("omd");

            Assert.IsTrue(obj.Equals(obj2));
        }


        [TestMethod]
        public void Test_GetHashCode()
        {
            var obj = new MockValuedDataObject()
            {
                ItemSubjectRef = new ItemDefinition { StructureRef = "test" },
                Id = "5",
                Name = "jack",

            };
            obj.SetValue("omd");

            var obj2 = new MockValuedDataObject()
            {
                ItemSubjectRef = new ItemDefinition { StructureRef = "test" },
                Id = "5",
                Name = "jack",

            };
            obj.SetValue("omd");
            obj2.SetValue("omd");

            Assert.IsTrue(obj.GetHashCode() == obj2.GetHashCode());
        }

    }

    public class MockValuedDataObject: ValuedDataObject
    {
        public override void SetValue(object value)
        {
            this.value = value;
        }
    }
}
