using System;
using System.Collections.Generic;
using System.Text;
using validoctor.Control;

namespace validoctor.Validator
{
    internal interface iValidator
    {
        bool isValid(iControl ctl);
    }
}
