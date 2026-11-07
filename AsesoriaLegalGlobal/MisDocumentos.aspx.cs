using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // para usar Directory, File, Path y FileInfo

namespace AsesoriaLegalGlobal
{
    public partial class MisDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PROTECCIÓN: si no inició sesión, no puede ver esta página y lo mandamos al login
            if (this.Session["logueado"] == null)
            {
                this.Response.Redirect("Login.aspx");
                return;
            }

            string usuario = this.Session["usuario"].ToString();
            this.lblTitulo.Text = "Espacio personal de " + usuario;

            // La lista se carga solo la primera vez; después de subir un archivo
            // se vuelve a cargar desde btnSubir_Click
            if (this.IsPostBack == false)
            {
                this.CargarDocumentos();
            }
        }

        // Devuelve la carpeta propia del usuario: Documentos/<usuario>.
        // Si no existe todavía, la crea. Así cada usuario tiene su propio espacio.
        private string ObtenerCarpetaUsuario()
        {
            string carpeta = this.Server.MapPath("~/Documentos/" + this.Session["usuario"].ToString());
            if (Directory.Exists(carpeta) == false)
            {
                Directory.CreateDirectory(carpeta);
            }
            return carpeta;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            // Mensajes de error por defecto en rojo; si todo sale bien se cambia a verde
            this.lblMensaje.CssClass = "mensaje-error";

            // 1) ¿Eligió un archivo?
            if (this.fuDocumento.HasFile == false)
            {
                this.lblMensaje.Text = "Seleccioná un archivo.";
                return;
            }

            // 2) ¿La extensión está permitida? Se pasa a minúsculas para que ".PDF" también valga
            string extension = Path.GetExtension(this.fuDocumento.FileName).ToLower();
            if (extension != ".pdf" && extension != ".doc" && extension != ".docx" &&
                extension != ".txt" && extension != ".jpg" && extension != ".png")
            {
                this.lblMensaje.Text = "El tipo de archivo " + this.Server.HtmlEncode(extension) + " no está permitido. Solo se aceptan PDF, DOC, DOCX, TXT, JPG y PNG.";
                return;
            }

            // 3) ¿Pesa 5 MB o menos? ContentLength está en bytes: 5 * 1024 * 1024 = 5 MB
            int tamanio = this.fuDocumento.PostedFile.ContentLength;
            if (tamanio > 5 * 1024 * 1024)
            {
                this.lblMensaje.Text = "El archivo supera el máximo de 5 MB.";
                return;
            }

            // 4) Nombre limpio: GetFileName se queda solo con "archivo.pdf" y descarta
            // cualquier ruta (por ejemplo "C:\..\..\archivo.pdf"), así no se puede guardar fuera de la carpeta
            string nombreArchivo = Path.GetFileName(this.fuDocumento.FileName);
            string rutaCompleta = Path.Combine(this.ObtenerCarpetaUsuario(), nombreArchivo);

            // El nombre lo eligió el usuario y un Label no "escapa" el HTML: con HtmlEncode
            // se muestra como texto y nadie puede meter etiquetas HTML en la página
            string nombreParaMostrar = this.Server.HtmlEncode(nombreArchivo);

            // 5) Si ya existe un archivo con ese nombre, no lo pisamos (Guía 08)
            if (File.Exists(rutaCompleta))
            {
                this.lblMensaje.Text = "Ya tenés un documento llamado " + nombreParaMostrar + ". Cambiale el nombre y volvé a subirlo.";
                return;
            }

            // 6) Todo correcto: guardamos el archivo y mostramos sus datos como en la Guía 08
            this.fuDocumento.SaveAs(rutaCompleta);
            this.lblMensaje.CssClass = "mensaje-exito";
            this.lblMensaje.Text = "Documento subido correctamente.<br />" +
                                   "Nombre: " + nombreParaMostrar + "<br />" +
                                   "Tamaño: " + tamanio.ToString() + " bytes<br />" +
                                   "Tipo: " + this.fuDocumento.PostedFile.ContentType;

            // Recargamos la lista para que aparezca el documento nuevo
            this.CargarDocumentos();
        }

        // Llena la lista con los archivos de la carpeta del usuario (nombre y tamaño)
        private void CargarDocumentos()
        {
            this.blDocumentos.Items.Clear();

            string[] archivos = Directory.GetFiles(this.ObtenerCarpetaUsuario());
            foreach (string ruta in archivos)
            {
                FileInfo info = new FileInfo(ruta);

                // Los archivos chicos se muestran en bytes y el resto en KB (1 KB = 1024 bytes)
                string tamanio;
                if (info.Length < 1024)
                {
                    tamanio = info.Length.ToString() + " bytes";
                }
                else
                {
                    double kb = info.Length / 1024.0;
                    tamanio = kb.ToString("0.0") + " KB";
                }

                this.blDocumentos.Items.Add(info.Name + " (" + tamanio + ")");
            }

            // Si no hay archivos mostramos un aviso en lugar de la lista vacía
            this.lblSinDocumentos.Visible = (archivos.Length == 0);
        }
    }
}
