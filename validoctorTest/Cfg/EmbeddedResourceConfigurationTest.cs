using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using validoctor.Cfg;
using System.Reflection;

namespace validoctorTest.Cfg
{
    [TestFixture]
    public class EmbeddedResourceConfigurationTest
    {
        MockRepository rep;
        iMappingConfiguration map;
        [SetUp]
        public void setUp()
        {
            rep = new MockRepository();
        }

        [Test]
        public void Initialize() 
        {
            map = new EmbeddedResourceConfiguration();
            Assert.IsNotNull(map);
            map = null;

            map = new EmbeddedResourceConfiguration(Assembly.GetExecutingAssembly().FullName, "pepe.xml");
            Assert.IsNotNull(map);
            map = null;
        }

        [Test]
        public void LoadAssembly()
        {
            string xmlFile = "CustomerScreen.xml";
            map = new EmbeddedResourceConfiguration(Assembly.GetExecutingAssembly().FullName, xmlFile);
            map.ProcessConfiguration();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NotSettingParamLoadAssembly()
        {
            string xmlFile = "CustomerScreen.xml";
            map = new EmbeddedResourceConfiguration(Assembly.GetExecutingAssembly().FullName,String.Empty);
            map.ProcessConfiguration();
            map = null;

            map = new EmbeddedResourceConfiguration(String.Empty,xmlFile);
            map.ProcessConfiguration();
            map = null;
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void FailLoadAssembly()
        {
            string xmlFile = "NonExists.xml";
            map = new EmbeddedResourceConfiguration(Assembly.GetExecutingAssembly().FullName, xmlFile);
            map.ProcessConfiguration();
        }

        [TearDown]
        public void tearDown()
        {
        }

    }
}
