<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CemEmlakV1._0._Default" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cem Emlak</h1>
        <p class="lead">Evinizde Huzurla ve Güvenle Oturun</p>
        <p><a href="AddHome" class="btn btn-primary btn-lg">Kendi evinizi sitemize eklemek için tıklayın</a></p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1069px" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Baslik" HeaderText="Başlık" SortExpression="Baslik" />
                <asp:BoundField DataField="Adres" HeaderText="Adres" SortExpression="Adres" />
                <asp:BoundField DataField="OdaSayisi" HeaderText="Oda Sayısı" SortExpression="OdaSayisi" />
                <asp:BoundField DataField="BanyoSayisi" HeaderText="Banyo Sayısı" SortExpression="BanyoSayisi" />
                <asp:BoundField DataField="Aciklama" HeaderText="Açıklama" SortExpression="Aciklama" />
                <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" SortExpression="Fiyat" />
                <asp:ButtonField ButtonType="Link" Text="Düzenle" CommandName="duzenle"/>
                <asp:ButtonField ButtonType="Button" Text="Sil" CommandName="sil">
                <ControlStyle BackColor="Red" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>    

</asp:Content>
