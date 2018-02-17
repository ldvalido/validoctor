using System;
using System.Collections.Generic;
using System.Text;
using validoctor.exceptions;
namespace validoctor.Validator
{
    public class NotNullNotEmptyValidator : iValidator
    {
        #region iValidator Members

        public bool isValid(validoctor.Control.iControl ctl)
        {
            bool returnValue = default(bool);
            if (ctl != null)
            {
                object obj = ctl.getValue();
                if (obj != null)
                {
                    returnValue = !String.IsNullOrEmpty(obj.ToString());
                }
                else
                {
                    returnValue = false; 
                }
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
