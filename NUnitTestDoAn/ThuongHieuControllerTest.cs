using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    class ThuongHieuControllerTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/DangNhap");
            dr.Manage().Window.Maximize();
        }



        //----------------------------------------------------------
        //Test chức năng thêm thương hiệu
        [Test]
        public void ThemThuongHieu_MaTHRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ THƯƠNG HIỆU")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();

            dr.FindElement(By.ClassName("btn")).Click();
            Assert.AreEqual("Mã thương hiệu không được để trống", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemThuongHieu_TenTHRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ THƯƠNG HIỆU")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("MaTH")).SendKeys("TH40");
            dr.FindElement(By.ClassName("btn")).Click();
            Assert.AreEqual("Tên thương hiệu không được để trống", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemThuongHieu_HinhAnhTHRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ THƯƠNG HIỆU")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();
            dr.FindElement(By.Id("MaTH")).SendKeys("TH23");
            dr.FindElement(By.Id("TenTH")).SendKeys("BUM BA YA");
            dr.FindElement(By.ClassName("btn")).Click();
            Assert.AreEqual("Vui lòng chọn ảnh bìa", dr.FindElement(By.Id("thongBao")).Text);
        }


        //----------------------------------------------------------
        //Test chức năng xóa thương hiệu
        [Test]
        public void XoaThuongHieu_KoHopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ THƯƠNG HIỆU")).Click();
            dr.FindElement(By.ClassName("btn-warning")).Click();
            dr.FindElement(By.Id("Xoa")).Click();
            Assert.AreNotEqual("Thương hiệu", dr.Title);
        }



        //----------------------------------------------------------
        //Test chức năng chi tiết thương hiệu
        [Test]
        public void ChiTietThuongHieu_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ THƯƠNG HIỆU")).Click();

            dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreEqual("Chi tiết thương hiệu", dr.Title);
        }

        [Test]
        public void ChiTietThuongHieu_KoTonTai()
        {
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/ChiTietThuongHieu/22");
            dr.Manage().Window.Maximize();
            Assert.AreNotEqual("Chi tiết thương hiệu", dr.Title);
        }
    }
}
