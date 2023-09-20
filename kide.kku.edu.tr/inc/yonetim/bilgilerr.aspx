<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bilgilerr.aspx.cs" Inherits="inc_yonetim_bilgilerr" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="100%" border="0">
        <tr>
            <td><h3>Anasayfa</h3></td>
            <td align="right">
                <asp:Button ID="anasayfaGuncelleBTN" runat="server" Text=" Güncelle" 
                    ValidationGroup="anasayfaGuncelle" CssClass="secBTN" OnClick="anasayfaGuncelleBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><textarea id="anasayfaTXT" name="hakkinda" ValidationGroup="anasayfaGuncelle" runat="server"></textarea></td>
        </tr>
    </table>
</asp:Content>
