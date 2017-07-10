using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INTECH_Form.Models;

namespace INTECH_Form
{
    [TestClass]
    public class INTECH_Form_Tests
    {
        [TestMethod]
        public void Test_Form()
        {
            Form f = new Form();
            Assert.IsNull(f.Title);
            f.Title = "My Form";
            Assert.AreEqual(f.Title, "My Form");
        }
    }
}
