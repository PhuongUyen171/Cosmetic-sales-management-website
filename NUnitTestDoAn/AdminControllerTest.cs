using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class AdminControllerTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng đăng nhập người dùng
        [Test]
        public void LoginAdmin_TenDanhMucRong()
        {
            dr.FindElement(By.PartialLinkText("Admin")).Click();
            dr.FindElement(By.Id("Nhap")).Click();
            Assert.AreEqual("Tên đăng nhập không được để trống.", dr.FindElement(By.ClassName("txt1")).Text);
        }

        [Test]
        public void LoginAdmin_MatKhauRong()
        {
            dr.FindElement(By.PartialLinkText("Admin")).Click();
            dr.FindElement(By.Id("TENDN")).SendKeys("abc");
            dr.FindElement(By.Id("Nhap")).Click();
            Assert.AreEqual("Mật khẩu không được để trống.", dr.FindElement(By.ClassName("txt1")).Text);
        }

        [Test]
        public void LoginAdmin_TaiKhoanKoTonTai()
        {
            dr.FindElement(By.PartialLinkText("Admin")).Click();
            dr.FindElement(By.Id("TENDN")).SendKeys("abc");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("abc");
            dr.FindElement(By.Id("Nhap")).Click();
            Assert.AreEqual("Tên đăng nhập hoặc mật khẩu không đúng", dr.FindElement(By.ClassName("txt1")).Text);
        }

        [Test]
        public void LoginAdmin_HopLe()
        {
            dr.FindElement(By.PartialLinkText("Admin")).Click();
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();
            Assert.AreEqual("Trang chủ admin", dr.Title);
        }
    }
}
