<%@ Page Title="Sınıf Ekle" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="sinifEkle.aspx.cs" Inherits="sinifEkle" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 244px;
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
                <img src="../../img/bilgi.png"/>
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
        <table style="width:51%; margin-left:-20px;" border="0">
            <tr>
                <td class="style3" style="width: 244px; text-align: right">Yeni Sınıf :</td>
                <td>
                    <asp:TextBox ID="sinifTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" ValidationGroup="sinif"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="sinifEkleBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Ekle" Width="50px" onclick="sinifEkleBTN_Click" 
                        ValidationGroup="sinif" />
                </td>
            </tr>
            <tr>
                <td class="style2">&nbsp;</td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="sinifTXT" ErrorMessage="Sınıf Adı Boş Bırakılamaz." 
                        ForeColor="White" ValidationGroup="sinif"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </center>
    </div> <!-- ...............Sag Son ........... -->
    <div class="clear"></div>
</asp:Content>
