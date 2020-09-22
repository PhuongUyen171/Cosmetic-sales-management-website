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
    public class AdminUITest
    {
        public AdminUITest()
        {
        }

        [TestMethod]
        public void FormLoginAdmin_SaiTenDangNhapHoacMatKhau()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/Admin/DangNhap");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "MSAA";
                txtTen.SearchProperties.Add("Name", "Email");
                txtTen.SearchProperties.Add("ControlType", "Edit");
                txtTen.DrawHighlight();
                Keyboard.SendKeys(txtTen, "admin");

                UITestControl txtPass = new UITestControl(browser);
                txtPass.TechnologyName = "MSAA";
                txtPass.SearchProperties.Add("Name", "Password");
                txtPass.SearchProperties.Add("ControlType", "Edit");
                txtPass.DrawHighlight();
                Keyboard.SendKeys(txtPass, "admin");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "LOGIN");
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
        public void FormLoginAdmin_TaiKhoanRong()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/Admin/DangNhap");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "LOGIN");
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
        public void FormLoginAdmin_MatKhauRong()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/Admin/DangNhap");
                browser.Maximized = true;
                browser.DrawHighlight();

                //UITestControl txtTen = new UITestControl(browser);
                //txtTen.TechnologyName = "MSAA";
                //txtTen.SearchProperties.Add("Name", "Email");
                //txtTen.SearchProperties.Add("ControlType", "Edit");
                //txtTen.DrawHighlight();
                //Keyboard.SendKeys(txtTen, "admin");

                UITestControl txtPass = new UITestControl(browser);
                txtPass.TechnologyName = "MSAA";
                txtPass.SearchProperties.Add("Name", "Password");
                txtPass.SearchProperties.Add("ControlType", "Edit");
                txtPass.DrawHighlight();
                Keyboard.SendKeys(txtPass, "admin");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "LOGIN");
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
        public void FormLoginAdmin_HopLe()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            try
            {
                BrowserWindow browser = BrowserWindow.Launch("http://localhost:12742/Admin/DangNhap");
                browser.Maximized = true;
                browser.DrawHighlight();

                UITestControl txtTen = new UITestControl(browser);
                txtTen.TechnologyName = "MSAA";
                txtTen.SearchProperties.Add("Name", "Email");
                txtTen.SearchProperties.Add("ControlType", "Edit");
                txtTen.DrawHighlight();
                Keyboard.SendKeys(txtTen, "PhuongUyen");

                UITestControl txtPass = new UITestControl(browser);
                txtPass.TechnologyName = "MSAA";
                txtPass.SearchProperties.Add("Name", "Password");
                txtPass.SearchProperties.Add("ControlType", "Edit");
                txtPass.DrawHighlight();
                Keyboard.SendKeys(txtPass, "1");

                UITestControl btnDangNhap = new UITestControl(browser);
                btnDangNhap.TechnologyName = "MSAA";
                btnDangNhap.SearchProperties.Add("Name", "LOGIN");
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
    }
}
