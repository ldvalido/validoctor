using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using validoctor.exceptions;

namespace validoctor.Utilities
{
    public class EmbeddedResourceHelper
    {
        public static Stream GetEmbeddedResource(string asmName, string resName)
        {
            Stream returnValue = null;
            if (!String.IsNullOrEmpty(asmName))
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(asmName);
                    if (!String.IsNullOrEmpty(resName))
                    {
                        returnValue = asm.GetManifestResourceStream(resName);
                    }
                    else
                    {
                        exceptionFactory.ThrowNullArgumentException("resName");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("asmName");
            }
            return returnValue;
        }
    }
}
