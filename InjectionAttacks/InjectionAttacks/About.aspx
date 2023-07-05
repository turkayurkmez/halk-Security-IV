<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" ValidateRequest="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p>&nbsp;</p>
    <p>
        <asp:TextBox ID="TextBoxComment" runat="server" Height="161px" TextMode="MultiLine" Width="542px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Yorum Ekle" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Label ID="LabelComment" runat="server" Text="Label"></asp:Label>
    </p>

</asp:Content>
