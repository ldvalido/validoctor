using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using validoctor.exceptions;

namespace validoctor.Cfg
{
    public class XmlMappingConfiguration : iMappingConfiguration
    {
        XmlDocument innerXml = new XmlDocument();

        #region Properties
        public XmlDocument XML
        {
            //get { return innerXml; }
            set 
            {
                //TODO: Determinate if throw an exception on a null value
                innerXml = value; 
            }
        }
        #endregion
        
        #region Con...tor
        public XmlMappingConfiguration()
        {
        }

        public XmlMappingConfiguration(string fileName)
        {
            LoadFile(fileName);
        }

        public XmlMappingConfiguration(XmlDocument xml)
        {
            if (xml != null)
            {
                innerXml = xml;
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("XML");    
            }
        }
        #endregion

        #region Public Methods
        public void LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                innerXml = new XmlDocument();
                innerXml.LoadXml(fileName);
            }
            else
            {
                throw new ArgumentException("The file does not exists");
            }
        }
        #endregion

        #region iMappingConfiguration Members

        public MappingConfiguration ProcessConfiguration()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
