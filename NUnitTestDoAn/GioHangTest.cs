using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class GioHangTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng giỏ hàng
        [Test]
        public void ThemGioHang_TrungSP()
        {
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            Assert.AreEqual("2", dr.FindElement(By.Id("solg")).Text);
        }

        [Test]
        public void ThemGioHang_KhacSP()
        {

            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Sản phẩm khác")).Click();
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            Assert.AreEqual("2", dr.FindElement(By.Id("solg")).Text);
        }

        [Test]
        public void CapNhatGioHang()
        {

            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            dr.FindElement(By.Id("soLuong")).Clear();
            dr.FindElement(By.Id("soLuong")).SendKeys("3");
            dr.FindElement(By.Id("btnCapNhat")).Click();
            Assert.AreEqual("3", dr.FindElement(By.Id("solg")).Text);
        }

        [Test]
        public void XoaGioHang_ConSanPham()
        {
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Sản phẩm khác")).Click();
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            dr.FindElement(By.PartialLinkText("Xóa")).Click();
            Assert.AreEqual("1", dr.FindElement(By.Id("solg")).Text);
        }

        [Test]
        public void XoaGioHang_HetSanPham()
        {
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            dr.FindElement(By.PartialLinkText("Xóa")).Click();
            Assert.AreEqual("Trang chủ",dr.Title);
        }

        [Test]
        public void XoaTatCaGioHang()
        {
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Make-Up")).Click();
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            dr.FindElement(By.PartialLinkText("Xóa tất cả giỏ hàng")).Click();
            Assert.AreEqual("Trang chủ", dr.Title);
        }

        [Test]
        public void DatHang_ThanhCong()
        {
            dr.FindElement(By.ClassName("hinhdf")).Click();
            dr.FindElement(By.Id("btnMua")).Click();
            dr.FindElement(By.PartialLinkText("Giỏ hàng")).Click();
            dr.FindElement(By.PartialLinkText("Đặt hàng")).Click();

            dr.FindElement(By.Name("usr")).SendKeys("UyenSoCute");
            dr.FindElement(By.Name("pass")).SendKeys("1");
            dr.FindElement(By.ClassName("btn-danger")).Click();

            dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreEqual("Xác nhận đơn hàng", dr.Title);
        }
    }
}
