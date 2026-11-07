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
            // IsValid es true solo si TODOS los validadores de la página se cumplen (Guía 07).
            // Se vuelve a controlar en el servidor por si el navegador no ejecutó la validación.
            if (this.IsValid)
            {
                // 1) Nombre de usuario en una variable de SESIÓN (se guarda en el servidor, Guía 09)
                this.Session["usuario"] = this.txtUsuario.Text;
                // También guardamos el nombre para saludar al cliente en el login
                this.Session["nombre"] = this.txtNombre.Text;
                // Si había alguien logueado, al registrar un usuario nuevo esa sesión deja de valer
                this.Session.Remove("logueado");

                // 2) Contraseña en una COOKIE (se guarda en el navegador del cliente, Guía 09).
                // OJO: guardar una contraseña en una cookie NO es seguro en un sistema real,
                // porque queda en la computadora del usuario y se puede leer con F12.
                // Lo correcto sería guardar un hash de la contraseña en una base de datos.
                // Se hace así porque es lo que pide la consigna del parcial.
                HttpCookie cookie1 = new HttpCookie("password", this.txtPassword.Text);
                cookie1.Expires = DateTime.Now.AddDays(7); // cookie persistente: dura 7 días
                this.Response.Cookies.Add(cookie1);

                // 3) Mensaje y redirección al login. Como Redirect cambia de página,
                // el aviso de "registro exitoso" lo muestra Login.aspx al cargarse.
                this.lblMensaje.Text = "Registro exitoso. Redirigiendo al inicio de sesión...";
                this.Response.Redirect("Login.aspx");
            }
        }
    }
}
