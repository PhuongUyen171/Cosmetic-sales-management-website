using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class PhanLoaiSPTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng phân loại sản phẩm theo danh mục
        [Test]
        public void FormMain_PhanLoaiTheoDanhMuc_CoSanPham()
        {
            dr.FindElement(By.PartialLinkText("Sản phẩm khác")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormMain_PhanLoaiTheoDanhMuc_KoSanPham()
        {
            dr.FindElement(By.PartialLinkText("Mỹ phẩm cao cấp")).Click();
            Assert.AreEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }



        //----------------------------------------------------------
        //Test chức năng phân loại sản phẩm theo thương hiệu
        [Test]
        public void FormMain_PhanLoaiTheoThuongHieu_CoSanPham()
        {
            dr.FindElement(By.PartialLinkText("GUCCI")).Click();
            Assert.AreNotEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }

        [Test]
        public void FormMain_PhanLoaiTheoThuongHieu_KoSanPham()
        {
            dr.FindElement(By.PartialLinkText("YA YA BUM BUM")).Click();
            Assert.AreEqual(0, dr.FindElements(By.ClassName("hieuUng")).Count);
        }
    }
}
