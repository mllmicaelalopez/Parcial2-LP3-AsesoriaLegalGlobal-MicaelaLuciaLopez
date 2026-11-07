<%@ Page Title="Mis Documentos - Asesoría Legal Global" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MisDocumentos.aspx.cs" Inherits="AsesoriaLegalGlobal.MisDocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>

    <!-- Subida de documentos (Guía 08) -->
    <div class="tarjeta">
        <h2>Subir un documento</h2>
        <p class="aclaracion">Formatos permitidos: PDF, DOC, DOCX, TXT, JPG y PNG. Tamaño máximo: 5 MB.</p>

        <div class="subida">
            <asp:FileUpload ID="fuDocumento" runat="server" />
            <asp:Button ID="btnSubir" runat="server" Text="Subir documento" CssClass="boton" OnClick="btnSubir_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
    </div>

    <!-- Lista de documentos que ya subió este usuario -->
    <div class="tarjeta">
        <h2>Mis documentos</h2>
        <asp:BulletedList ID="blDocumentos" runat="server" CssClass="lista-documentos"></asp:BulletedList>
        <asp:Label ID="lblSinDocumentos" runat="server" CssClass="aclaracion" Text="Todavía no subiste ningún documento."></asp:Label>
    </div>

</asp:Content>
