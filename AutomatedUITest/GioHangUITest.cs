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
    public class GioHangUITest
    {
        public GioHangUITest()
        {
        }

        [TestMethod]
        public void TC1_ThemGioHang()
        {
            this.UIMap.RecordedMethod_ThemGioHang();
            this.UIMap.AssertMethod_SoLuongSP();
            this.UIMap.AssertMethod_TongSL();
            this.UIMap.AssertMethod_DonGia();
            this.UIMap.AssertMethod_ThanhTien();

        }

        [TestMethod]
        public void TC1_CapNhatGioHang()
        {
            this.UIMap.RecordedMethod_CapNhatGioHang();
            this.UIMap.AssertMethod_TongSLCapNhat();
            this.UIMap.AssertMethod_TongTien();
            this.UIMap.AssertMethod_DonGia();
        }

        [TestMethod]
        public void TC2_CapNhatGioHang()
        {
            Random r = new Random();
            int a = r.Next(1,10);
            this.UIMap.RecordedMethod_CapNhatGioHangParams.UIItemSpinnerSendKeys = a+"";
            this.UIMap.AssertMethod_TongSLCapNhatExpectedValues.UIItem5EditName = a + "";
            string gia = "260,000 VNĐ";
            this.UIMap.AssertMethod_DonGiaExpectedValues.UIItem260000VNĐEditName = gia;
            this.UIMap.AssertMethod_TongTienExpectedValues.UIItem2340000VNĐEditFriendlyName = a * Convert.ToInt32(gia.Remove(gia.Length - 9, 9)) * 1000 + " VNĐ";


            this.UIMap.RecordedMethod_CapNhatGioHang();
            this.UIMap.AssertMethod_TongSLCapNhat();
            this.UIMap.AssertMethod_TongTien();
            this.UIMap.AssertMethod_DonGiaCapNhat();
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
