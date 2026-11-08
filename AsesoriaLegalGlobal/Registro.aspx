<%@ Page Title="Registro - Asesoría Legal Global" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AsesoriaLegalGlobal.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tarjeta formulario">
        <h1>Registro de clientes</h1>
        <p class="aclaracion">Todos los campos son obligatorios.</p>

        <div class="campo">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre y Apellido" AssociatedControlID="txtNombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="60"></asp:TextBox>
            <%-- RequiredFieldValidator (Guía 07) --%>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Ingresá tu nombre y apellido." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico" AssociatedControlID="txtCorreo"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server" MaxLength="80"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Ingresá tu correo electrónico." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

            <%-- RegularExpressionValidator (Guía 07) --%>
            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="El correo no tiene un formato válido (ejemplo: nombre@dominio.com)." Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblUsuario" runat="server" Text="Nombre de usuario" AssociatedControlID="txtUsuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                ErrorMessage="Ingresá un nombre de usuario." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtUsuario"
                ValidationExpression="[a-zA-Z0-9_]{3,20}"
                ErrorMessage="El usuario debe tener entre 3 y 20 letras, números o guion bajo (sin espacios ni acentos)." Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblEdad" runat="server" Text="Edad" AssociatedControlID="txtEdad"></asp:Label>
            <asp:TextBox ID="txtEdad" runat="server" MaxLength="3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEdad" runat="server" ControlToValidate="txtEdad"
                ErrorMessage="Ingresá tu edad." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

            <%-- RangeValidator (Guía 07) --%>
            <asp:RangeValidator ID="rvEdad" runat="server" ControlToValidate="txtEdad"
                Type="Integer" MinimumValue="16" MaximumValue="120"
                ErrorMessage="La edad debe ser un número entero mayor de 15 años." Display="Dynamic" CssClass="error"></asp:RangeValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Ingresá una contraseña." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblConfirmar" runat="server" Text="Confirmar contraseña" AssociatedControlID="txtConfirmar"></asp:Label>
            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmar" runat="server" ControlToValidate="txtConfirmar"
                ErrorMessage="Repetí la contraseña." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

            <%-- CompareValidator (Guía 07) --%>
            <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmar" ControlToCompare="txtPassword"
                Operator="Equal" Type="String"
                ErrorMessage="Las contraseñas no coinciden." Display="Dynamic" CssClass="error"></asp:CompareValidator>
        </div>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="boton" OnClick="btnRegistrar_Click" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
    </div>

</asp:Content>
