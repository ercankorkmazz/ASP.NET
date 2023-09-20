<%@ Page Title="Öğretmen Sorgula" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="kullaniciAyarlari.aspx.cs" Inherits="ogretmenKayit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            width: 351px;
        }
        .style4
        {
            width: 120px;
            height: 30px;
        }
        .style5
        {
            width: 183px;
            height: 30px;
        }
        .style6
        {
            height: 30px;
            text-align: left;
            color: #FF0000;
        }
        .style7
        {
            color: #FF0000;
        }
        .style8
        {
            width: 39%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <table border="0" width="100%">
    <tr>
        <td class="style8"><h2>KULLANICI AYARLARI</h2></td>
        <td align="right" class="style3">
            &nbsp;<asp:Label ID="bilgiTXT" 
                runat="server" Font-Bold="True" 
            ForeColor="Black" style="text-align: left" CssClass="bilgi" Font-Size="14px"></asp:Label>
        </td>
        <td align="left" style="width:25px;">
            <asp:Panel ID="bilgiIMG" runat="server">
                <img src="../img/bilgi.png"/>
            </asp:Panel>
        </td>
    </tr>
   </table>
    <div class="SagBolum" style="width:900px;height:auto;float:none;">
        <center>
        <table style="width:72%;margin-left:140px;" border=0>
        
            <tr>
                <td colspan=2 style="text-align: right">
                    &nbsp;
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td style="width:120px;">
                    <h3>kullanıcı adı:</h3>
                </td>
                <td style="width:183px;">
                    <asp:TextBox ID="kadiTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" style="font-weight:bold; text-align:center;"></asp:TextBox>
                </td>
                <td style="text-align: left"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="kadiTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="kullaniciAyarlari"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <h3>Mevcut şifre:</h3>
                </td>
                <td class="style5">
                    <asp:TextBox ID="mSifreTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" TextMode="Password" style="font-weight:bold; text-align:center;"></asp:TextBox>
                </td>
                <td class="style6">*
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    <h3>şifre:</h3>
                </td>
                <td class="style5">
                    <asp:TextBox ID="ySifreTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" TextMode="Password" style="font-weight:bold; text-align:center;"></asp:TextBox>
                </td>
                <td class="style6">*
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    <h3>şifre tekrarı:</h3>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tSifreTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px" TextMode="Password" style="font-weight:bold; text-align:center;"></asp:TextBox>
                </td>
                <td class="style6">*
                    </td>
            </tr>
 
            <tr>
                <td colspan=2 style="text-align: right">
                    <asp:Button ID="kullaniciGuncelleBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Güncelle" Width="80px" 
                        style="text-align: right"
                        ValidationGroup="kullaniciAyarlari" onclick="kullaniciGuncelleBTN_Click" />
                    <br />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
