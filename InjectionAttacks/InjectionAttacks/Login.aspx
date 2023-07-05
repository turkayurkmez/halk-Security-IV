<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:TextBox ID="TextBoxUserName" placeholder="User Name" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br />
    <asp:TextBox ID="TextBoxPassword" placeholder="Password" TextMode="Password" runat="server" ></asp:TextBox><br />
    <asp:Button ID="ButtonLogin" runat="server" Text="Giriş Yap" OnClick="ButtonLogin_Click" /><br />
   
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
   
</asp:Content>
