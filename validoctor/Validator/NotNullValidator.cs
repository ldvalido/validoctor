using System;
using System.Collections.Generic;
using System.Text;
using validoctor.exceptions;

namespace validoctor.Validator
{
    public class NotNullValidator : iValidator
    {
        #region iValidator Members

        public bool isValid(validoctor.Control.iControl ctl)
        {
            bool returnValue = default(bool);
            if (ctl != null) 
            {
                returnValue = (ctl.getValue() != null);
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("ctl");
            }
            return returnValue;
        }
        #endregion
    }
}
