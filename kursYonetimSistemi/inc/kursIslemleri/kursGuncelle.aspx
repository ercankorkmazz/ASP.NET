<%@ Page Title="Kurs Güncelle" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="kursGuncelle.aspx.cs" Inherits="kursGuncelle" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 106px;
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
        <table style="width:46%; margin-left:7px;" border="0">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <h3>
                        Kurs Güncelle
                    </h3>
                </td>
                <td>
                    <asp:Label ID="kusID" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Kurs Seçiniz:</td>
                <td>
                    <asp:DropDownList ID="kursSecListele" runat="server" BackColor="#3ed4dd"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="kursSec" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" onclick="kursSec_Click" Text="Seç" Width="40px" 
                        style="text-align: right" />
                </td>
            </tr>
        </table>
        <table style="width:68%; margin-left:160px;margin-top:15px;" border="0">
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Kursun Adı:</td>
                <td class="style2">
                    <asp:TextBox ID="kusAdiTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="kusAdiTXT" ErrorMessage="Bu alan boş bırakılamaz." 
                        ForeColor="White" ValidationGroup="guncelle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Fiyat (TL):</td>
                <td class="style2">
                    <asp:TextBox ID="fiyatTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="fiyatTXT" ErrorMessage="Bu alan boş bırakılamaz." 
                        ForeColor="White" ValidationGroup="guncelle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Kontenjan:</td>
                <td class="style2">
                    <asp:TextBox ID="kontenjanTXT" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="kontenjanTXT" ErrorMessage="Bu alan boş bırakılamaz." 
                        ForeColor="White" ValidationGroup="guncelle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Süre:</td>
                <td class="style2">
                    <asp:DropDownList ID="kursSuresi" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px">
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
                <td></td>
            </tr>
            <tr>
                <td class="style3" style="width: 102px; text-align: right">Öğretmen:</td>
                <td class="style2">
                    <asp:DropDownList ID="ogretmenler" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="190px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td colspan=2 style="text-align: right">
                    <asp:Button ID="kursSil" runat="server" BorderColor="#000066" 
                        BorderStyle="Solid" BorderWidth="1px" ForeColor="#465C71" Height="30px" 
                        onclick="kursSil_Click" Text="Sil" Width="52px" />
&nbsp;<asp:Button ID="kursGun0" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Güncelle" Width="65px" onclick="kursGuncelle_Click" 
                        ValidationGroup="guncelle" />
                </td>
                <td></td>
            </tr>
        </table>
    </center>
    </div>
</asp:Content>
