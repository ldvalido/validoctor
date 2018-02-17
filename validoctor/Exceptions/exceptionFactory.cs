using System;
using System.Collections.Generic;
using System.Text;

namespace validoctor.exceptions
{
    public class exceptionFactory
    {
        public static void ThrowNullArgumentException(string argName)
        {
            throw new ArgumentNullException(String.Format(Messages.NullArgument, argName));
        }

        public static void ThrowAssemblyDoesntExist(string asmName)
        {
            throw new ArgumentException(String.Format("The assembly {0} doesn't exists", asmName));
        }
        
        public static void ThrowArgumentNotSettedException()
        {
            throw new ArgumentException("The argument _assembly and _resource must be setted");
        }
    }
}
