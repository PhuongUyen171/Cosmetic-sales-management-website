using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using System.Web;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace NUnitTestDoAn
{
    public class SanPhamControllerTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/DangNhap");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng thêm sản phẩm
        [Test]
        public void ThemSP_TenSPRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();

            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên sản phẩm không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemSP_GiaBanRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("TENSP")).SendKeys("abc");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Giá sản phẩm không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemSP_SoLuongRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("TENSP")).SendKeys("abc");
            dr.FindElement(By.Id("GIA")).SendKeys("50000");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Vui lòng nhập số lượng tồn.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemSP_HinhAnhRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("TENSP")).SendKeys("abc");
            dr.FindElement(By.Id("GIA")).SendKeys("50000");
            dr.FindElement(By.Id("SL")).SendKeys("50");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Vui lòng chọn ảnh sản phẩm", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemSP_HinhAnhKoHopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("TENSP")).SendKeys("abc");
            dr.FindElement(By.Id("GIA")).SendKeys("50000");
            dr.FindElement(By.Id("SL")).SendKeys("50");
            //FileAssert f= dr.FindElement(By.Name("fileUpload"));
            
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Vui lòng chọn ảnh sản phẩm", dr.FindElement(By.Id("thongBao")).Text);
        }
        
        [Test]
        public void ThemSP_HinhAnhTrung()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("TENSP")).SendKeys("abc");
            dr.FindElement(By.Id("GIA")).SendKeys("50000");
            dr.FindElement(By.Id("SL")).SendKeys("50");
            dr.FindElement(By.Name("fileUpload")).SendKeys("http://localhost:12742/Content/HinhAnh/SanPham/Tinh%20Ch%E1%BA%A5t%20The%20Body%20Shop%20Tea%20Tree.JPG");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Hình ảnh đã tồn tại", dr.FindElement(By.Id("thongBao")).Text);
        }



        //-----------------------------------------------------------
        //Test chức năng chi tiết sản phẩm
        [Test]
        public void ChiTietSP_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();
            dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreEqual("Chi tiết sản phẩm", dr.Title);
        }

        //-----------------------------------------------------------
        //Test chức năng xóa sản phẩm
        [Test]
        public void XoaSP_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();

            dr.FindElement(By.ClassName("btn-warning")).Click();
            dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreEqual("Sản phẩm", dr.Title);
        }

        [Test]
        public void XoaSP_KoHopLe()
        {
        
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/XoaSanPham/SP13");
            dr.Manage().Window.Maximize();
            //dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            //dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            //dr.FindElement(By.Id("Nhap")).Click();

            //dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            //dr.FindElement(By.ClassName("btn-warning")).Click();

            dr.FindElement(By.Id("Xoa")).Click();
            //Assert.AreEqual("Danh mục", dr.Title);

            //dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            //dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            //dr.FindElement(By.Id("Nhap")).Click();

            //dr.FindElement(By.PartialLinkText("QUẢN LÝ SẢN PHẨM")).Click();

            //dr.FindElement(By.ClassName("btn-warning")).Click();
            //dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreNotEqual("Sản phẩm", dr.Title);
        }
    }
}
