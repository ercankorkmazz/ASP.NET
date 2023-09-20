<%@ Page Title="Sınıf Sil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="sinifSil.aspx.cs" Inherits="sinifSil" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
        <table style="width:50%; margin-left:0px;" border="0">
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Sınıf Sil :</td>
                <td>
                    <asp:DropDownList ID="siniflar" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px" onselectedindexchanged="siniflar_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="sinifSilBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Seçili Sınıfı Sil" Width="110px" onclick="sinifSilBTN_Click" />
                </td>
            </tr>
        </table>
    </center>
    </div> <!-- ...............Sag Son ........... -->
    <div class="clear"></div>
</asp:Content>
