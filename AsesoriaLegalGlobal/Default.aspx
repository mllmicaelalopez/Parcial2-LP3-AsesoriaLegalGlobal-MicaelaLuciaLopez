<%@ Page Title="Inicio - Asesoría Legal Global" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AsesoriaLegalGlobal.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Portada: banner de la empresa (logo 3) y botones para empezar -->
    <section class="portada">
        <img src="img/logo3.png" alt="Banner de Asesoría Legal Global" class="banner" />
        <h1>Bienvenido a Asesoría Legal Global</h1>
        <p>
            Somos una consultora que asesora a personas y empresas en temas legales.
            Desde tu espacio personal podés subir y tener a mano tus contratos,
            poderes, escritos y cualquier documento que necesites compartir con nosotros.
        </p>
        <div class="botones">
            <asp:HyperLink ID="lnkRegistrarme" runat="server" NavigateUrl="~/Registro.aspx" CssClass="boton">Registrarme</asp:HyperLink>
            <asp:HyperLink ID="lnkIniciarSesion" runat="server" NavigateUrl="~/Login.aspx" CssClass="boton boton-secundario">Iniciar sesión</asp:HyperLink>
        </div>
    </section>

    <!-- Servicios: tres tarjetas que en celular quedan una debajo de la otra -->
    <h2>Nuestros servicios</h2>
    <section class="servicios">
        <div class="tarjeta">
            <h3>Derecho civil y de familia</h3>
            <p>Sucesiones, divorcios, alimentos y contratos entre particulares.</p>
        </div>
        <div class="tarjeta">
            <h3>Derecho laboral</h3>
            <p>Despidos, liquidaciones y asesoramiento a trabajadores y empleadores.</p>
        </div>
        <div class="tarjeta">
            <h3>Derecho comercial</h3>
            <p>Constitución de sociedades, contratos comerciales y marcas.</p>
        </div>
    </section>

    <!-- Quiénes somos: usa el logo 1 de la empresa -->
    <section class="nosotros tarjeta">
        <img src="img/logo1.png" alt="Logo institucional" class="logo-nosotros" />
        <div>
            <h2>Quiénes somos</h2>
            <p>
                Un equipo de abogados con experiencia en distintas ramas del derecho.
                Trabajamos con turnos online y gestión digital de documentos para
                que no tengas que ir y venir con papeles.
            </p>
        </div>
    </section>

</asp:Content>
