using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriaLegalGlobal
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // IsValid (Guía 07)
            if (this.IsValid)
            {
                // Cookie vs Session (Guía 09)
                this.Session["usuario"] = this.txtUsuario.Text;
                this.Session["nombre"] = this.txtNombre.Text;
                this.Session.Remove("logueado");

                HttpCookie cookie1 = new HttpCookie("password", this.txtPassword.Text);
                cookie1.Expires = DateTime.Now.AddDays(7);
                this.Response.Cookies.Add(cookie1);

                this.lblMensaje.Text = "Registro exitoso. Redirigiendo al inicio de sesión...";
                // Response.Redirect (Guías 07 y 09)
                this.Response.Redirect("Login.aspx");
            }
        }
    }
}
