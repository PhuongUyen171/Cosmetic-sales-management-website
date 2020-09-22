using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace AutomatedUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NguoiDungUITest
    {
        public NguoiDungUITest()
        {
        }

        //FORM ĐĂNG NHẬP
        [TestMethod]
        public void FormLoginKH_SaiTenDangNhapHoacMatKhau()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl btnLogin = new UITestControl(browser);
                btnLogin.TechnologyName = "MSAA";
                btnLogin.SearchProperties.Add("Name","Đăng nhập");
                btnLogin.SearchProperties.Add("ControlType", "Edit");
                btnLogin.DrawHighlight();
                Mouse.Click(btnLogin);

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "MSAA";
                txtTen.SearchProperties.Add("Name", "Nhập tài khoản ...");
                txtTen.SearchProperties.Add("ControlType", "Edit");
                txtTen.DrawHighlight();
                Keyboard.SendKeys(txtTen, "admin");

                UITestControl txtPass = new UITestControl(browser);
                txtPass.TechnologyName = "MSAA";
                txtPass.SearchProperties.Add("Name", "Mật khẩu ...");
                txtPass.SearchProperties.Add("ControlType", "Edit");
                txtPass.DrawHighlight();
                Keyboard.SendKeys(txtPass, "admin");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "Đăng nhập");
                btnDangNhap.SearchProperties.Add("ControlType", "Button");
                btnDangNhap.DrawHighlight();
                Mouse.Click(btnDangNhap);

                Playback.Wait(1000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
            
        }

        [TestMethod]
        public void FormLoginKH_TenDangNhapRong()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl btnLogin = new UITestControl(browser);
                btnLogin.TechnologyName = "MSAA";
                btnLogin.SearchProperties.Add("Name", "Đăng nhập");
                btnLogin.SearchProperties.Add("ControlType", "Edit");
                btnLogin.DrawHighlight();
                Mouse.Click(btnLogin);

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "Đăng nhập");
                btnDangNhap.SearchProperties.Add("ControlType", "Button");
                btnDangNhap.DrawHighlight();
                Mouse.Click(btnDangNhap);

                Playback.Wait(1000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

        }

        [TestMethod]
        public void FormLoginKH_MatKhauRong()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/");
                browser.Maximized = true;
                browser.DrawHighlight();
                //Playback.Wait(5000);

                UITestControl btnLogin = new UITestControl(browser);
                btnLogin.TechnologyName = "MSAA";
                btnLogin.SearchProperties.Add("Name", "Đăng nhập");
                btnLogin.SearchProperties.Add("ControlType", "Edit");
                btnLogin.DrawHighlight();
                Mouse.Click(btnLogin);
                //Playback.Wait(500);

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "MSAA";
                txtTen.SearchProperties.Add("Name", "Nhập tài khoản ...");
                txtTen.SearchProperties.Add("ControlType", "Edit");
                txtTen.DrawHighlight();
                Keyboard.SendKeys(txtTen, "admin");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "Đăng nhập");
                btnDangNhap.SearchProperties.Add("ControlType", "Button");
                btnDangNhap.DrawHighlight();
                Mouse.Click(btnDangNhap);

                Playback.Wait(1000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

        }

        [TestMethod]
        public void FormLoginKH_HopLe()
        {

            //this.UIMap.TenDangNhapRong();
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/");
                browser.Maximized = true;
                browser.DrawHighlight();
                //Playback.Wait(5000);

                UITestControl btnLogin = new UITestControl(browser);
                btnLogin.TechnologyName = "MSAA";
                btnLogin.SearchProperties.Add("Name", "Đăng nhập");
                btnLogin.SearchProperties.Add("ControlType", "Edit");
                btnLogin.DrawHighlight();
                Mouse.Click(btnLogin);
                //Playback.Wait(500);

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "MSAA";
                txtTen.SearchProperties.Add("Name", "Nhập tài khoản ...");
                txtTen.SearchProperties.Add("ControlType", "Edit");
                txtTen.DrawHighlight();
                Keyboard.SendKeys(txtTen, "UyenSoCute");

                UITestControl txtPass = new UITestControl(browser);
                txtPass.TechnologyName = "MSAA";
                txtPass.SearchProperties.Add("Name", "Mật khẩu ...");
                txtPass.SearchProperties.Add("ControlType", "Edit");
                txtPass.DrawHighlight();
                Keyboard.SendKeys(txtPass, "1");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "Đăng nhập");
                btnDangNhap.SearchProperties.Add("ControlType", "Button");
                btnDangNhap.DrawHighlight();
                Mouse.Click(btnDangNhap);

                Playback.Wait(1000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

        }

        //FORM ĐĂNG KÍ
        [TestMethod]
        public void FormSignInKH_TenDangNhapRong()
        {
            //this.UIMap.RecordedFormSignIn1();
            //this.UIMap.AssertMethod_TenDangNhapRong();
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl btnSign = new UITestControl(browser);
                btnSign.TechnologyName = "MSAA";
                btnSign.SearchProperties.Add("Name", "Đăng ký");
                btnSign.SearchProperties.Add("ControlType", "Edit");
                btnSign.DrawHighlight();
                Mouse.Click(btnSign);

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "Web";
                txtTen.SearchProperties.Add("Name", "HoTen");
                Keyboard.SendKeys(txtTen, "Nguyễn Văn A");
                //txtTen.SearchProperties.Add("ControlType", "Edit");
                //txtTen.DrawHighlight();
                //Keyboard.SendKeys(txtTen, "UyenSoCute");

                //UITestControl txtPass = new UITestControl(browser);
                //txtPass.TechnologyName = "MSAA";
                //txtPass.SearchProperties.Add("Name", "Mật khẩu ...");
                //txtPass.SearchProperties.Add("ControlType", "Edit");
                //txtPass.DrawHighlight();
                //Keyboard.SendKeys(txtPass, "1");

                UITestControl btnDangKy = new UITestControl(browser);
                btnDangKy.TechnologyName = "MSAA";
                btnDangKy.SearchProperties.Add("ControlType", "Button");
                btnDangKy.SearchProperties.Add("Name", "ĐĂNG KÝ");
                btnDangKy.DrawHighlight();
                Mouse.Click(btnDangKy);

                //Playback.Wait(1000);
                UITestControl kq = new UITestControl(browser);
                kq.TechnologyName = "Web";
                kq.SearchProperties.Add("ControlType", "Cell");
                Assert.AreEqual(kq, "Tên đăng nhập không được để trống.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        //lỗi
        [TestMethod]
        public void FormSignInKH_MatKhauRong()
        {
            this.UIMap.RecordedMethod_MatKhauRong();
            this.UIMap.AssertMethod_MatKhauRong();

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
