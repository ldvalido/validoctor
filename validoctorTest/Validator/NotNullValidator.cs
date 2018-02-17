using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using validoctor.Control;
using validoctor.Validator;

namespace validoctorTest.Validator
{
    [TestFixture]
    public class NotNullValidatorTest
    {
        MockRepository rep;
        iControl ictl;

        [SetUp]
        public void setup()
        {
            rep = new MockRepository();
            ictl = rep.Stub<iControl>();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void isValidWithNull()
        {
            NotNullValidator val = new NotNullValidator();
            val.isValid(null);
        }

        [Test]
        public void isValid()
        {
            NotNullValidator val = new NotNullValidator();

            ictl = rep.Stub<iControl>();
            Expect.On(ictl).Call(ictl.getValue()).Return(String.Empty);

            rep.ReplayAll();
            Assert.IsTrue(val.isValid(ictl));
        }

        [Test]
        public void isValidWithValue()
        {
            NotNullValidator val = new NotNullValidator();
            Expect.On(ictl).Call(ictl.getValue()).Return(
                "pepe"
                    );
            rep.ReplayAll();
            Assert.IsTrue(val.isValid(ictl));
        }

        [Test]
        public void isValidWithNullValue()
        {
            NotNullValidator val = new NotNullValidator();
            Expect.On(ictl).Call(
                ictl.getValue()).Return(
                    null
                    );
            rep.ReplayAll();
            Assert.IsFalse(val.isValid(ictl));
        }

        [TearDown]
        public void TearDown()
        {
            ictl = null;
            rep = null;
        }
    }
}
