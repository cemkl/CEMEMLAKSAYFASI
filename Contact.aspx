<%@ Page Title="İletişim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CemEmlakV1._0.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>İletişim Bilgilerimiz</p>

    <address>
        Ankara<br />
        Çankaya, Cinnah Caddesi 2A/3<br />
        <abbr title="0538 123 45 67"></abbr>
    </address>

    <address>
        <strong>Destek:</strong><a href="cemkulak:destek@cememlak.com">destek@cememlak.com</a><br />
        <strong>Satış:</strong><a href="cemkulak:satis@cememlak.com">satis@cememlak.com</a>
    </address>
</asp:Content>
