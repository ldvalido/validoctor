using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using validoctor.Utilities;
using System.Reflection;
using System.IO;
namespace validoctorTest.Utilities
{
    [TestFixture]
    public class UtilitiesTest
    {
        [SetUp]
        public void setUp()
        {
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void testWithOutAsmArg() 
        {
            EmbeddedResourceHelper.GetEmbeddedResource(String.Empty, "CustomerScreen.xml");
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void testWithOutResArg() 
        {
            EmbeddedResourceHelper.GetEmbeddedResource(Assembly.GetExecutingAssembly().FullName, String.Empty);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void testWithIncorrectAssemblyName() 
        {
            string asmName = "NonExists.xml";
            EmbeddedResourceHelper.GetEmbeddedResource(asmName, String.Empty);
        }

        [Test]
        public void testCorrect()
        {
            string asmName = "CustomerScreen.xml";
            Stream str = EmbeddedResourceHelper.GetEmbeddedResource(Assembly.GetExecutingAssembly().FullName, asmName);
            Assert.IsNotNull(str);
        }

        [TearDown]
        public void TearDown() { }
    }
}
