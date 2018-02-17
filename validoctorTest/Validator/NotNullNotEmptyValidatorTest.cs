using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using validoctor.Validator;
using validoctor.Control;

namespace validoctorTest.Validator
{
    [TestFixture]
    public class NotNullNotEmptyValidatorTest
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
            NotNullNotEmptyValidator val = new NotNullNotEmptyValidator();
            val.isValid(null);
        }

        [Test]
        public void isValid()
        {
            NotNullNotEmptyValidator val = new NotNullNotEmptyValidator();

            ictl = rep.Stub<iControl>();
            Expect.On(ictl).Call(ictl.getValue()).Return(String.Empty);

            rep.ReplayAll();
            Assert.IsFalse(val.isValid(ictl));
        }

        [Test]
        public void isValidWithValue()
        {
            NotNullNotEmptyValidator val = new NotNullNotEmptyValidator();
            Expect.On(ictl).Call(ictl.getValue()).Return(
                "pepe"
                    );
            rep.ReplayAll();
            Assert.IsTrue(val.isValid(ictl));
        }

        [Test]
        public void isValidWithNullValue()
        {
            NotNullNotEmptyValidator val = new NotNullNotEmptyValidator();
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
