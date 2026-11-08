using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriaLegalGlobal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack (Guía 09)
            if (this.IsPostBack == false)
            {
                if (this.Session["usuario"] != null && this.Session["logueado"] == null)
                {
                    this.lblMensaje.Text = "¡Registro exitoso, " + this.Session["nombre"].ToString() + "! Ya podés iniciar sesión.";
                    this.lblMensaje.CssClass = "mensaje-exito";
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Cookie vs Session (Guía 09)
                if (this.Session["usuario"] == null || this.Request.Cookies["password"] == null)
                {
                    this.lblMensaje.Text = "Primero debés registrarte.";
                    this.lblMensaje.CssClass = "mensaje-error";
                }
                else
                {
                    string usuarioGuardado = this.Session["usuario"].ToString();
                    string passwordGuardada = this.Request.Cookies["password"].Value;

                    if (this.txtUsuario.Text == usuarioGuardado && this.txtPassword.Text == passwordGuardada)
                    {
                        // Response.Redirect (Guías 07 y 09)
                        this.Session["logueado"] = true;
                        this.Response.Redirect("MisDocumentos.aspx");
                    }
                    else
                    {
                        this.lblMensaje.Text = "Usuario o contraseña incorrectos.";
                        this.lblMensaje.CssClass = "mensaje-error";
                    }
                }
            }
        }
    }
}
