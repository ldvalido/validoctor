using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace validoctor.Control
{
    public interface iControl
    {
        System.Windows.Forms.Control control{set;get;}
        object getValue();
    }
}
