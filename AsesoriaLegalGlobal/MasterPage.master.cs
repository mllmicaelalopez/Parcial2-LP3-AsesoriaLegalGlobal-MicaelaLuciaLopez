using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriaLegalGlobal
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cookie vs Session (Guía 09)
            if (this.Session["logueado"] != null)
            {
                this.lblSaludo.Text = "Hola, " + this.Session["usuario"].ToString();
                this.lblSaludo.Visible = true;
                this.lnkCerrarSesion.Visible = true;

                this.lnkRegistro.Visible = false;
                this.lnkLogin.Visible = false;
            }
            else
            {
                this.lblSaludo.Visible = false;
                this.lnkCerrarSesion.Visible = false;
                this.lnkRegistro.Visible = true;
                this.lnkLogin.Visible = true;
            }
        }
    }
}
