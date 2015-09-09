using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Services;

namespace TextMatch.Test
{
    [TestClass]
    public class TextMatchingTests
    {
        private const string Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
        private const string FailedText = "There is no output";
        private const string NullText = "Please provide Text and Subtext";
        private TextMatchingService _unitUnderTest;
        
        [TestInitialize]
        public void Initialise()
        {
            _unitUnderTest = new TextMatchingService();
        }

        [TestMethod]
        public void Test_Text_NULL()
        {
            var result = _unitUnderTest.Match(null, "Polly");

            Assert.AreEqual(NullText, result);
        }

        [TestMethod]
        public void Test_Subtext_NULL()
        {
            var result = _unitUnderTest.Match(Text, null);

            Assert.AreEqual(NullText, result);
        }

        [TestMethod]
        public void Test_Text_EMPTY()
        {
            var result = _unitUnderTest.Match("", "Polly");

            Assert.AreEqual(NullText, result);
        }

        [TestMethod]
        public void Test_Subtext_EMPTY()
        {
            var result = _unitUnderTest.Match(Text, "");

            Assert.AreEqual(NullText, result);
        }

        [TestMethod]
        public void Test_Text_SPACE()
        {
            var result = _unitUnderTest.Match(" ", "Polly");

            Assert.AreEqual(NullText, result);
        }

        [TestMethod]
        public void Test_Subtext_SPACE()
        {
            var result = _unitUnderTest.Match(Text, " ");

            Assert.AreEqual(NullText, result);
        }


        [TestMethod]
        public void Test_Subtext_Polly()
        {
            var result = _unitUnderTest.Match(Text, "Polly");

            Assert.AreEqual("1,26,51", result);
        }

        [TestMethod]
        public void Test_Subtext_ll()
        {
            var result = _unitUnderTest.Match(Text, "ll");

            Assert.AreEqual("3,28,53,78,82", result);
        }

        [TestMethod]
        public void Test_Subtext_X()
        {
            var result = _unitUnderTest.Match(Text, "X");

            Assert.AreEqual(FailedText, result);
        }

        [TestMethod]
        public void Test_Subtext_Polx()
        {
            var result = _unitUnderTest.Match(Text, "Polx");

            Assert.AreEqual(FailedText, result);
        }

        [TestMethod]
        public void Test_Subtext_ly()
        {
            var result = _unitUnderTest.Match(Text, "ly");

            Assert.AreEqual("4,29,54", result);
        }

        [TestMethod]
        public void Test_Subtext_put()
        {
            var result = _unitUnderTest.Match(Text, "put");

            Assert.AreEqual("7,32,57", result);
        }

        [TestMethod]
        public void Test_Subtext_p()
        {
            var result = _unitUnderTest.Match(Text, "p");

            Assert.AreEqual("1,7,26,32,51,57", result);
        }

        [TestMethod]
        public void Test_Subtext_Pully()
        {
            var result = _unitUnderTest.Match(Text, "Pully");

            Assert.AreEqual(FailedText, result);
        }

        [TestMethod]
        public void Test_Text_AAAA_Subtext_AA()
        {
            var result = _unitUnderTest.Match("AAAA", "AA");

            Assert.AreEqual("1,3", result);
        }
    }
}