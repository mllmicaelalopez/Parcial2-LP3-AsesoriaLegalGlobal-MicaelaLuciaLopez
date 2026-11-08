using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriaLegalGlobal
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session.Abandon (Guía 09)
            this.Session.Abandon();

            this.Response.Redirect("Default.aspx");
        }
    }
}
