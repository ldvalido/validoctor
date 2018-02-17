using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using validoctor.exceptions;

namespace validoctor.Control
{
    public class TextBoxControl : iControl
    {
        System.Windows.Forms.Control ctl;
        
        #region iControl Members
        
        public object getValue()
        {
            string returnValue = String.Empty;
            if (ctl != null)
            {
                returnValue = ((TextBox)ctl).Text;
            }
            else
            {
                exceptionFactory.ThrowNullArgumentException("ctl");
            }
            return returnValue;
        }

        public System.Windows.Forms.Control control
        {
            get
            {
                return ctl;
            }
            set
            {
                //TODO: View the action with a null value
                ctl = value;
            }
        }

        #endregion
    }
}
