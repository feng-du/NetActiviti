using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetActiviti.BPMN.Model.Test
{
    [TestClass]
    public class TestAssociationDirection
    {
        [TestMethod]
        public void Test_GetValue()
        {
            var val = AssociationDirection.ONE;

            var description = val.GetValue();

            Assert.AreEqual("One", description);
        }
    }
}
