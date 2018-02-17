using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using validoctor.Control;
using validoctor.Validator;
using System.Windows.Forms;

namespace validoctorTest.Validator
{
    [TestFixture]
    public class NotEmptyValidatorTest
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
            NotEmptyValidator val = new NotEmptyValidator();
            val.isValid(null);
        }

        [Test]
        public void isValid()
        {
            NotEmptyValidator val = new NotEmptyValidator();

            ictl = rep.Stub<iControl>();
            Expect.On(ictl).Call(ictl.getValue()).Return(String.Empty);

            rep.ReplayAll();
            Assert.IsFalse(val.isValid(ictl));
        }

        [Test]
        public void isValidWithValue()
        {
            NotEmptyValidator val = new NotEmptyValidator();
            Expect.On(ictl).Call(ictl.getValue()).Return(
                "pepe"
                    );
            rep.ReplayAll();
            Assert.IsTrue(val.isValid(ictl));
        }


        [TearDown]
        public void TearDown()
        {
            ictl = null;
            rep = null;
        }
    }
}
