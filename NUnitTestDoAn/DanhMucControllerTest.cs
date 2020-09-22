using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class DanhMucControllerTest
    {
        IWebDriver dr = new FirefoxDriver();

        [SetUp]
        public void Setup()
        {
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/DangNhap");
            dr.Manage().Window.Maximize();
        }

        //----------------------------------------------------------
        //Test chức năng thêm danh mục
        [Test]
        public void ThemDanhMuc_TenDanhMucRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();

            dr.FindElement(By.ClassName("btn")).Click();
            Assert.AreEqual("Tên danh mục không được để trống", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void ThemDanhMuc_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();

            dr.FindElement(By.Id("TenTL")).SendKeys("Mỹ phẩm cao cấp1");
            dr.FindElement(By.ClassName("btn")).Click();
            
            Assert.AreEqual("Danh mục",dr.Title);
        }

        [Test]
        public void ThemDanhMuc_TenDanhMucTrung()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();
            dr.FindElement(By.LinkText("THÊM MỚI")).Click();

            dr.FindElement(By.Id("TenTL")).SendKeys("Mỹ phẩm cao cấp");
            dr.FindElement(By.ClassName("btn")).Click();
            Assert.AreEqual("Tên danh mục đã bị trùng. Vui lòng nhập tên khác.", dr.FindElement(By.Id("thongBao")).Text);
        }



        //----------------------------------------------------------
        //Test chức năng chi tiết danh mục
        [Test]
        public void ChiTietDanhMuc_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            dr.FindElement(By.ClassName("btn-secondary")).Click();
            Assert.AreEqual("Chi tiết danh mục", dr.Title);
        }

        [Test]
        public void ChiTietDanhMuc_KoTonTai()
        {
            //dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            //dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            //dr.FindElement(By.Id("Nhap")).Click();

            //dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            //dr.FindElement(By.ClassName("btn-secondary")).Click();
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/ChiTietDanhMuc/22");
            dr.Manage().Window.Maximize();
            Assert.AreNotEqual("Chi tiết danh mục", dr.Title);
        }


        //----------------------------------------------------------
        //Tét chức năng xóa danh mục
        [Test]
        public void XoaDanhMuc_HopLe()
        {
            dr.Navigate().GoToUrl("http://localhost:12742/Admin/XoaDanhMuc/12");
            dr.Manage().Window.Maximize();
            dr.FindElement(By.Id("Xoa")).Click();
            Assert.AreEqual("Danh mục", dr.Title);
        }

        [Test]
        public void XoaDanhMuc_KoThanhCong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            dr.FindElement(By.ClassName("btn-warning")).Click();
            dr.FindElement(By.Id("Xoa")).Click();
            Assert.AreNotEqual("Danh mục", dr.Title);
        }



        //----------------------------------------------------------
        //Test chức năng sửa danh mục
        [Test]
        public void SuaDanhMuc_HopLe()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            dr.FindElement(By.ClassName("btn-danger")).Click();
            dr.FindElement(By.Id("TENTL")).Clear();
            dr.FindElement(By.Id("TENTL")).SendKeys("Tên danh mục đã được sửa.");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Danh mục", dr.Title);
        }

        [Test]
        public void SuaDanhMuc_TenDanhMucRong()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            dr.FindElement(By.ClassName("btn-danger")).Click();
            dr.FindElement(By.Id("TENTL")).Clear();
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên danh mục không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void SuaDanhMuc_TenDanhMucTrung()
        {
            dr.FindElement(By.Id("TENDN")).SendKeys("PhuongUyen");
            dr.FindElement(By.Id("MATKHAU")).SendKeys("1");
            dr.FindElement(By.Id("Nhap")).Click();

            dr.FindElement(By.PartialLinkText("QUẢN LÝ DANH MỤC")).Click();

            dr.FindElement(By.ClassName("btn-danger")).Click();
            dr.FindElement(By.Id("TENTL")).Clear();
            dr.FindElement(By.Id("TENTL")).SendKeys("Sản phẩm khác");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên danh mục đã bị trùng. Vui lòng nhập tên khác.", dr.FindElement(By.Id("thongBao")).Text);
        }
    }
}