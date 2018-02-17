using System;
using System.Collections.Generic;
using System.Text;
using validoctor.exceptions;

namespace validoctor.Validator
{
    public class NotEmptyValidator : iValidator
    {
        #region iValidator Members

        public bool isValid(validoctor.Control.iControl ctl)
        {
            bool returnValue = default(bool);
            if (ctl != null)
            {
                string value =ctl.getValue().ToString(); 
                returnValue = value!= String.Empty;
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
