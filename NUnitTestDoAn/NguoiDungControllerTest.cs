using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestDoAn
{
    public class NguoiDungControllerTest
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
        public void LoginNguoiDung_TenDanhMucRong()
        {
            dr.FindElement(By.PartialLinkText("Đăng nhập")).Click();
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên đăng nhập không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void LoginNguoiDung_PasswordRong()
        {
            dr.FindElement(By.PartialLinkText("Đăng nhập")).Click();
            dr.FindElement(By.Name("usr")).SendKeys("abc");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Mật khẩu không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void LoginNguoiDung_TaiKhoanKoTonTai()
        {
            dr.FindElement(By.PartialLinkText("Đăng nhập")).Click();
            dr.FindElement(By.Name("usr")).SendKeys("abc");
            dr.FindElement(By.Name("pass")).SendKeys("abc");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên đăng nhập hoặc mật khẩu không đúng.", dr.FindElement(By.Id("thongBao2")).Text);
            
        }

        [Test]
        public void LoginNguoiDung_HopLe()
        {
            dr.FindElement(By.PartialLinkText("Đăng nhập")).Click();
            dr.FindElement(By.Name("usr")).SendKeys("UyenSoCute");
            dr.FindElement(By.Name("pass")).SendKeys("1");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Trang chủ", dr.Title);

        }



        //----------------------------------------------------------
        //Test chức năng đăng ký người dùng
        [Test]
        public void SignInNguoiDung_TenDangNhapRong()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên đăng nhập không được để trống.",dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void SignInNguoiDung_MatKhauRong()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.Id("TaiKhoan")).SendKeys("abc1223");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Mật khẩu không được để trống.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void SignInNguoiDung_XacNhanMatKhauRong()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.Id("TaiKhoan")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK1")).SendKeys("abc1223");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Người dùng phải xác nhận lại mật khẩu.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void SignInNguoiDung_MatKhauKoTrungKhop()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.Id("TaiKhoan")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK1")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK2")).SendKeys("abc");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Mật khẩu và xác nhận mật khẩu không trùng khớp.", dr.FindElement(By.Id("thongBao")).Text);
        }

        [Test]
        public void SignInNguoiDung_HopLe()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.Id("TaiKhoan")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK1")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK2")).SendKeys("abc1223");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Đăng nhập", dr.Title);
        }

        [Test]
        public void SignInNguoiDung_TaiKhoanTonTai()
        {
            dr.FindElement(By.PartialLinkText("Đăng ký")).Click();
            dr.FindElement(By.Id("HoTen")).SendKeys("Trần Văn Thọ");
            dr.FindElement(By.Id("DiaChi")).SendKeys("Thừa Thiên Huế");
            dr.FindElement(By.Id("Sdt")).SendKeys("0123456789");
            dr.FindElement(By.Id("TaiKhoan")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK1")).SendKeys("abc1223");
            dr.FindElement(By.Id("MK2")).SendKeys("abc1223");
            dr.FindElement(By.ClassName("btn-danger")).Click();
            Assert.AreEqual("Tên đăng nhập đã tồn tại. Vui lòng đặt lại tên.", dr.FindElement(By.Id("thongBao")).Text);
        }
    }
}
