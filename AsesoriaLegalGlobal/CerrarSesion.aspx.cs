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
            // Abandon destruye TODAS las variables de sesión de este usuario
            // (usuario, nombre y logueado). La cookie "password" queda en el navegador
            // hasta que vence, pero sin la sesión ya no alcanza para entrar.
            this.Session.Abandon();

            // Volvemos a la página de inicio
            this.Response.Redirect("Default.aspx");
        }
    }
}
