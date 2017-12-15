using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPro;

namespace TestPro.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void IsNullOrWhiteSpaceTest()
        {
            string str1 = string.Empty;
            Assert.IsTrue(str1.IsNullOrWhiteSpace());
            string str2 = "";
            Assert.IsTrue(str2.IsNullOrWhiteSpace());
            string str3 = "    ";
            Assert.IsTrue(str3.IsNullOrWhiteSpace());
        }
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string test1 = "1234567890";
        string test2 = "123456";
        string test3 = "12345678901234567890";
        string test4 = "12345612345678901234567890";
        string test5 = null;

        [TestMethod]
        public void TestMethod1()
        {
            Extensions.SubString(test1);
            Extensions.SubString(test2);
            Extensions.SubString(test3);
            Extensions.SubString(test4);
            Extensions.SubString(test5);
        }

        [TestMethod]
        public void IsNullOrWhiteSpace()
        {
            string phone1 = "15563718522";

            Assert.IsTrue(phone1.IsPhone(), "错误");

            string phone2 = "123";

            Assert.IsFalse(phone2.IsPhone(), "错误");

            Assert.IsFalse(phone1.IsNullOrWhiteSpace(), "错误信息");

            Assert.IsFalse(phone1.IsNullOrEmpty(), "错误信息");

            string str = null;
            Assert.IsTrue(str.IsNullOrWhiteSpace(), "Error");
            string str2 = "";
            Assert.IsTrue(str2.IsNullOrWhiteSpace(), "Error");
            string str3 = " ";
            Assert.IsTrue(str3.IsNullOrWhiteSpace(), "Error");

        }
    }
}
