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

            FormAnswer a = f.FindOrCreateAnswers("Julie");
            Assert.IsNotNull(a);
            FormAnswer b = f.FindOrCreateAnswers("Julie");
            Assert.AreSame(a, b);

            Assert.AreEqual(1, f.AnswerCount);
            FormAnswer c = f.FindOrCreateAnswers("Joe");
            Assert.AreNotSame(a, c);
        }

        [TestMethod]
        public void Test_CreateQuestions()
        {
            Form f = new Form();
            f.Questions.Title = "AH-828";
            Assert.AreEqual("AH-828", f.Questions.Title);
        }
    }
}
