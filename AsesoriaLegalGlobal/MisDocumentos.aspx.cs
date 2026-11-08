using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AsesoriaLegalGlobal
{
    public partial class MisDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Redirect (Guías 07 y 09)
            if (this.Session["logueado"] == null)
            {
                this.Response.Redirect("Login.aspx");
                return;
            }

            string usuario = this.Session["usuario"].ToString();
            this.lblTitulo.Text = "Espacio personal de " + usuario;

            // IsPostBack (Guía 09)
            if (this.IsPostBack == false)
            {
                this.CargarDocumentos();
            }
        }

        private string ObtenerCarpetaUsuario()
        {
            // Server.MapPath (Guía 08)
            string carpeta = this.Server.MapPath("~/Documentos/" + this.Session["usuario"].ToString());
            if (Directory.Exists(carpeta) == false)
            {
                Directory.CreateDirectory(carpeta);
            }
            return carpeta;
        }

        // FileUpload (Guía 08)
        protected void btnSubir_Click(object sender, EventArgs e)
        {
            this.lblMensaje.CssClass = "mensaje-error";

            if (this.fuDocumento.HasFile == false)
            {
                this.lblMensaje.Text = "Seleccioná un archivo.";
                return;
            }

            // Directory, File y Path (System.IO, Guía 08)
            string extension = Path.GetExtension(this.fuDocumento.FileName).ToLower();
            if (extension != ".pdf" && extension != ".doc" && extension != ".docx" &&
                extension != ".txt" && extension != ".jpg" && extension != ".png")
            {
                this.lblMensaje.Text = "El tipo de archivo " + this.Server.HtmlEncode(extension) + " no está permitido. Solo se aceptan PDF, DOC, DOCX, TXT, JPG y PNG.";
                return;
            }

            int tamanio = this.fuDocumento.PostedFile.ContentLength;
            if (tamanio > 5 * 1024 * 1024)
            {
                this.lblMensaje.Text = "El archivo supera el máximo de 5 MB.";
                return;
            }

            string nombreArchivo = Path.GetFileName(this.fuDocumento.FileName);
            string rutaCompleta = Path.Combine(this.ObtenerCarpetaUsuario(), nombreArchivo);

            string nombreParaMostrar = this.Server.HtmlEncode(nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                this.lblMensaje.Text = "Ya tenés un documento llamado " + nombreParaMostrar + ". Cambiale el nombre y volvé a subirlo.";
                return;
            }

            this.fuDocumento.SaveAs(rutaCompleta);
            this.lblMensaje.CssClass = "mensaje-exito";
            this.lblMensaje.Text = "Documento subido correctamente.<br />" +
                                   "Nombre: " + nombreParaMostrar + "<br />" +
                                   "Tamaño: " + tamanio.ToString() + " bytes<br />" +
                                   "Tipo: " + this.fuDocumento.PostedFile.ContentType;

            this.CargarDocumentos();
        }

        private void CargarDocumentos()
        {
            this.blDocumentos.Items.Clear();

            string[] archivos = Directory.GetFiles(this.ObtenerCarpetaUsuario());
            foreach (string ruta in archivos)
            {
                FileInfo info = new FileInfo(ruta);

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

            this.lblSinDocumentos.Visible = (archivos.Length == 0);
        }
    }
}
