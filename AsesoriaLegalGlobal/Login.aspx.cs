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
            // Solo la primera vez que se pide la página (no cuando se presiona "Ingresar")
            if (this.IsPostBack == false)
            {
                // Si viene recién registrado, hay usuario en sesión pero todavía no está logueado
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
                // Antes de comparar, verificamos que existan la sesión y la cookie (igual que en la Guía 09).
                // Si alguna es null, la persona nunca se registró (o la sesión ya expiró).
                if (this.Session["usuario"] == null || this.Request.Cookies["password"] == null)
                {
                    this.lblMensaje.Text = "Primero debés registrarte.";
                    this.lblMensaje.CssClass = "mensaje-error";
                }
                else
                {
                    // El usuario se compara con la SESIÓN y la contraseña con la COOKIE
                    string usuarioGuardado = this.Session["usuario"].ToString();
                    string passwordGuardada = this.Request.Cookies["password"].Value;

                    if (this.txtUsuario.Text == usuarioGuardado && this.txtPassword.Text == passwordGuardada)
                    {
                        // Datos correctos: marcamos la sesión como iniciada y vamos al espacio personal
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
