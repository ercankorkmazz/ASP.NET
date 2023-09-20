<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bilgiler.aspx.cs" Inherits="inc_yonetim_bilgiler" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="100%" border="0">
        <tr>
            <td><h3>Anasayfa</h3></td>
            <td align="right">
                <asp:Button ID="anasayfaGuncelleBTN" runat="server" Text=" Güncelle" 
                    ValidationGroup="grupEkle" CssClass="secBTN" OnClick="anasayfaGuncelleBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><textarea id="anasayfaTXT" name="hakkinda" class="ckeditor" runat="server"></textarea></td>
        </tr>
        <tr>
            <td style="padding-top:20px;"><h3>Proje Hakkında</h3></td>
            <td style="padding-top:20px;" align="right">
                <asp:Button ID="girisBilgileriGuncelleBTN" runat="server" Text=" Giriş Bilgilerini Güncelle" 
                    ValidationGroup="grupEkle" CssClass="secBTN" OnClick="girisBilgileriGuncelleBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><textarea id="hakkindaTXT" name="hakkinda" class="ckeditor" runat="server"></textarea></td>
        </tr>
        <tr>
            <td colspan="2"><h3>Proje Ekibi</h3></td>
        </tr>
        <tr>
            <td colspan="2"><textarea id="ekipTXT" name="hakkinda" class="ckeditor" runat="server"></textarea></td>
        </tr>
        <tr>
            <td colspan="2"><h3>Yayınlar</h3></td>
        </tr>
        <tr>
            <td colspan="2"><textarea id="yayinlarTXT" name="hakkinda" class="ckeditor" runat="server"></textarea></td>
        </tr>
    </table>
</asp:Content>
