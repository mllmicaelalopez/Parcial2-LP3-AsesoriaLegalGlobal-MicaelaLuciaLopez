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
            // Este Page_Load se ejecuta en TODAS las páginas, porque todas heredan de la Master.
            // Session["logueado"] se crea en Login.aspx cuando el usuario y la contraseña coinciden.
            if (this.Session["logueado"] != null)
            {
                // Hay sesión iniciada: saludamos y mostramos "Cerrar sesión"
                this.lblSaludo.Text = "Hola, " + this.Session["usuario"].ToString();
                this.lblSaludo.Visible = true;
                this.lnkCerrarSesion.Visible = true;

                // Ya no tiene sentido registrarse ni iniciar sesión otra vez
                this.lnkRegistro.Visible = false;
                this.lnkLogin.Visible = false;
            }
            else
            {
                // No hay sesión: mostramos Registrarse e Iniciar sesión
                this.lblSaludo.Visible = false;
                this.lnkCerrarSesion.Visible = false;
                this.lnkRegistro.Visible = true;
                this.lnkLogin.Visible = true;
            }
        }
    }
}
