using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class TimKiemTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng tìm kiếm trên thanh menu
        [Test]
        public void FormTimKiemMenu_TextboxRong()
        {
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormTimKiemMenu_TextboxKoTonTai()
        {
            dr.FindElement(By.Name("tim")).SendKeys("abc");
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormTimKiemMenu_TextboxTonTai()
        {
            dr.FindElement(By.Name("tim")).SendKeys("innisfree");
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }



        //----------------------------------------------------------
        //Test chức năng tìm kiếm trên trang sản phẩm
        [Test]
        public void FormTimKiemSP_SanPhamRong()
        {
            dr.FindElement(By.PartialLinkText("Sản phẩm")).Click();
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormTimKiemSP_SanPhamKoTonTai()
        {
            dr.FindElement(By.PartialLinkText("Sản phẩm")).Click();
            dr.FindElement(By.Id("tim")).SendKeys("abc");
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormTimKiemSP_SanPhamTonTai()
        {
            dr.FindElement(By.PartialLinkText("Sản phẩm")).Click();
            dr.FindElement(By.Name("ma")).SendKeys("9");
            dr.FindElement(By.Name("btnTim")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }
    }
}
