# Asesoría Legal Global – Parcial 2 (TP4) LP3

Sitio web para la consultora legal **Asesoría Legal Global**: los clientes se registran, inician sesión y suben documentos legales a su propio espacio personal. Trabajo práctico del Parcial 2 de Laboratorio de Programación 3 (ISSD).

**Alumna:** Micaela López

## Tecnologías

- ASP.NET Web Forms sobre .NET Framework 4.8, con C# en code-behind
- Master Page propia (plantilla Vacío, sin Bootstrap)
- Controles de validación de ASP.NET (Guía 07)
- FileUpload y clases `Directory`, `File` y `Path` de `System.IO` (Guía 08)
- Cookies y variables de sesión (Guía 09)
- CSS propio y responsivo con `@media`, con la paleta de colores de los logos de la empresa
- Sin base de datos: el usuario vive en la sesión y la contraseña en una cookie, como pide la consigna

## Cómo ejecutarlo

1. Abrir `AsesoriaLegalGlobal.sln` con Visual Studio 2022.
2. Si aparece un aviso de paquetes NuGet faltantes: clic derecho en la solución → **Restaurar paquetes NuGet**.
3. Presionar **F5** (o Ctrl+F5). Se abre `Default.aspx` en IIS Express.
4. Recorrido sugerido: **Registrarse** → **Iniciar sesión** → **Mis Documentos** → subir un archivo → **Cerrar sesión**.

> Al cerrar sesión se borra la sesión, y con ella el usuario. Para volver a entrar hay que registrarse otra vez: es la consecuencia de no usar base de datos.

## Estructura

```
AsesoriaLegalGlobal/
├─ MasterPage.master      Encabezado con logo, navbar y footer comunes a todas las páginas
├─ Default.aspx           Inicio: presentación de la empresa con sus logos
├─ Registro.aspx          Formulario de registro con validaciones
├─ Login.aspx             Inicio de sesión (compara con la sesión y la cookie)
├─ MisDocumentos.aspx     Espacio personal: subida segura y listado de documentos
├─ CerrarSesion.aspx      Session.Abandon() y vuelta al inicio
├─ css/estilos.css        Única hoja de estilos (enlazada solo en la Master)
├─ img/                   logo1.png, logo2.png, logo3.png
└─ Documentos/            Una subcarpeta por usuario con sus archivos (no se sube a Git)
```

## Mapeo con la rúbrica

| Criterio | Puntos | Dónde se cumple |
|---|---|---|
| Master Page base para registro y gestión | 10 | `MasterPage.master`: todas las páginas usan `MasterPageFile="~/MasterPage.master"` |
| Navbar con enlaces funcionales | 10 | `asp:HyperLink` en la Master; `Page_Load` muestra u oculta enlaces según haya sesión |
| Footer en todas las páginas | 10 | `<footer class="pie">` en la Master |
| Campos del registro | 15 | `Registro.aspx`: nombre y apellido, correo, usuario, edad, contraseña y confirmación |
| Validaciones | 15 | `RequiredFieldValidator` en los 6 campos, `RegularExpressionValidator` (correo), `CompareValidator` (contraseñas), `RangeValidator` (edad entera de 16 a 120) |
| Contraseña en cookie y usuario en sesión | 10 | `btnRegistrar_Click`: `Session["usuario"]` y `HttpCookie("password")` |
| Redirección post-login al espacio personal | 15 | `Login.aspx.cs`: `Session["logueado"] = true` y `Response.Redirect("MisDocumentos.aspx")` |
| Carga segura de documentos | 15 | `MisDocumentos.aspx.cs`: sesión obligatoria, carpeta por usuario, extensión permitida, máximo 5 MB, `Path.GetFileName`, `File.Exists` sin pisar archivos; la carpeta `Documentos` está bloqueada por URL en `Web.config` |
| Bono: CSS responsivo | +10 | `css/estilos.css`: `@media (max-width: 768px)`, navbar vertical, formularios al 100 % e imágenes con `max-width: 100%` |
| Bono: imágenes de la empresa | +10 | logo 2 en el encabezado, logo 3 como banner en Inicio, logo 1 en "Quiénes somos" y en el footer; los colores del CSS salen de los logos |

## Nota de seguridad

Guardar la contraseña en una cookie **no es seguro** en un sistema real: queda en el navegador y se puede ver con F12. Lo correcto sería guardar un *hash* de la contraseña en una base de datos. Acá se hace así porque lo pide la consigna.
