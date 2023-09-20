<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            text-align: right;
            font-weight: bold;
            width: 89px;
        }
        .style5
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td><h2>Kurs İşlemleri</h2></td>
        <td align="right" class="style3">
            &nbsp;<asp:Label ID="bilgiTXT" 
                runat="server" Font-Bold="True" 
            ForeColor="Black" style="text-align: left" CssClass="bilgi" Font-Size="14px"></asp:Label>
        </td>
        <td align="left" style="width:25px;">
            <asp:Panel ID="bilgiIMG" runat="server">
                <img src="img/bilgi.png"/>
            </asp:Panel>
        </td>
    </tr>
   </table>
    <div class="SolBolum">
        
        <asp:TreeView ID="TreeView1" runat="server" CssClass="yanMenu" 
            ImageSet="BulletedList4" ShowExpandCollapse="False">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="Kurs Ekle" Value="KursEkle" NavigateUrl="~/Default.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Kurs Güncelle" Value="Kurs Guncelle" 
                    NavigateUrl="~/inc/kursIslemleri/kursGuncelle.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Sınıf Ekle" Value="SınıfEkle" 
                    NavigateUrl="~/inc/kursIslemleri/sinifEkle.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Sınıf Sil" Value="SınıfSil" 
                    NavigateUrl="~/inc/kursIslemleri/sinifSil.aspx"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        
    </div> <!-- ...............Sol Son ........... -->

    <div class="SagBolum">
    <center>
        <table style="width:38%; margin-left:-20px;" border="0">
            <tr>
                <td colspan=2 style="text-align: right">
                    <h3 style="float: right;">
                        Kurs Ekle
                    </h3>
                </td>
            </tr>
            <tr>
                <td class="style3">Kursun Adı:</td>
                <td>
                    <asp:TextBox ID="kursTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" ValidationGroup="Ekle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">Fiyat (TL):</td>
                <td>
                    <asp:TextBox ID="fiyatTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" ValidationGroup="Ekle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">Kontenjan:</td>
                <td>
                    <asp:TextBox ID="kontenjanTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" ValidationGroup="Ekle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">Süre:</td>
                <td>
                    <asp:DropDownList ID="kusSuresi" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px" ValidationGroup="Ekle">
                        <asp:ListItem Value="0">1 Hafta</asp:ListItem>
                        <asp:ListItem Value="1">2  Hafta</asp:ListItem>
                        <asp:ListItem Value="2">3 Hafta</asp:ListItem>
                        <asp:ListItem Value="3">4 Hafta</asp:ListItem>
                        <asp:ListItem Value="4">2 Ay</asp:ListItem>
                        <asp:ListItem Value="5">3 Ay</asp:ListItem>
                        <asp:ListItem Value="6">4 Ay</asp:ListItem>
                        <asp:ListItem Value="7">6 Ay</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">Öğretmen:</td>
                <td class="style5">
                    <asp:DropDownList ID="ogretmenler" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px" ValidationGroup="Ekle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan=2 style="text-align: right">
                    <asp:Button ID="kursKaydetBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" onclick="btnGonder_Click" Text="Ekle" Width="60px" 
                        ValidationGroup="Ekle"  />
                </td>
            </tr>
        </table>
    </center>
    </div> <!-- ...............Sag Son ........... -->
    <div class="clear"></div>
    </asp:Content>
