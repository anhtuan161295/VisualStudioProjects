using Lab08.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace Lab08.Tests
{
    //[TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController test = new HomeController();
            ViewResult res = test.Index() as ViewResult;
        }
    }
}