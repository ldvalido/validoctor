using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using validoctor.Control;

namespace validoctorTest.Control
{
    [TestFixture]
    public class TextBoxTest
    {
        MockRepository rep;
        iControl iCtl;
        System.Windows.Forms.Control ctl;

        [SetUp]
        public void setup()
        {
            rep = new MockRepository();
            iCtl = rep.Stub<iControl>();
            ctl = (System.Windows.Forms.Control)rep.StrictMock(typeof(System.Windows.Forms.Control));
        }

        [Test]
        public void getsetControlTest()
        {

            Assert.IsNull(iCtl.control);

            iCtl.control = ctl;
            Assert.IsTrue(iCtl.control == ctl);

            iCtl.control = null;
            Assert.IsNull(iCtl.control);
        }

        [Test]
        public void getValueWithValue()
        {
            iCtl.control = ctl;
            Assert.AreEqual(iCtl.control, ctl);
            Assert.IsNotNull(iCtl.control);
        }

        [Test]
        public void getValueWithNullValue()
        {
            Assert.IsNull(iCtl.control);
        }

        [Test]
        public void getValueWithoutControl()
        {
            Assert.IsNull(iCtl.control);
        }
    }
}
