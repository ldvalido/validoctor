using System;
using System.Collections.Generic;
using System.Text;
using validoctor.exceptions;
using System.Reflection;
using System.IO;
using System.Xml;

namespace validoctor.Cfg
{
    public class EmbeddedResourceConfiguration:iMappingConfiguration
    {
        #region Fields
        string _assembly;
        string _resource;
        #endregion
        
        #region Properties
        public string Assembly
        {
            get { return _assembly; }
            set { _assembly = value; }
        }
        public string Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }
        #endregion

        #region Con...tor
        public EmbeddedResourceConfiguration()
        {
        }

        public EmbeddedResourceConfiguration(string AssemblyName,string resourceName)
        {
            if (!String.IsNullOrEmpty(AssemblyName))
            {
                _assembly = AssemblyName;
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("assemblyName");    
            }

            if (!String.IsNullOrEmpty(resourceName))
            {
                _resource = resourceName;
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("resourceName");    
            }
        }
        #endregion

        #region iMappingConfiguration Members

        public MappingConfiguration ProcessConfiguration()
        {
            if (!String.IsNullOrEmpty(_assembly) && !String.IsNullOrEmpty(_resource))
            {
                try 
                {
                    XmlDocument _xml = new XmlDocument();
                    Assembly asm;
                    asm = System.Reflection.Assembly.LoadFile(_assembly); 
                    Stream str = asm.GetManifestResourceStream(_resource);
                    _xml.Load(str);
                }catch
                {
                    exceptionFactory.ThrowAssemblyDoesntExist(_assembly);
                }
            }
            else
            {
                exceptionFactory.ThrowArgumentNotSettedException();
            }
            return null;
        }

        #endregion
    }
}
