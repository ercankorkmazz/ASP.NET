<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ayarlar.aspx.cs" Inherits="ayarlar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center><h3>Kullanıcı Ayarları</h3></center>
    <div id="Accordion1" class="Accordion" tabindex="0">
      <div class="AccordionPanel">
        <div class="AccordionPanelTab">Ad Soyad / Kullanıcı Adı Güncelle</div>
        <div class="AccordionPanelContent">

            <table border="0" style="width:100%;">
                <tr>
                    <td colspan="2">
                        <h4 style="padding-bottom:0;">Ad Soyad Güncelle</h4>
                    </td>
                </tr>
                <tr>
                    <td style="width:700px;">
                        <asp:TextBox ID="adSoyadTXT" placeholder="Ad soyad yazınız." runat="server" CssClass="ayarlarTXT" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                    </td>
                    <td style="vertical-align:middle;padding-top:2px;">
                        <asp:Button ID="kadiGuncelleBTN" runat="server" Text="Güncelle" CssClass="kaydetBTN" OnClick="adSoyadGuncelleBTN_Click" ValidationGroup="adSoyad" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h4 style="padding-bottom:0;">Kullanıcı Adı Güncelle</h4>
                    </td>
                </tr>
                <tr>
                    <td style="width:700px;">
                        <asp:TextBox ID="kadiTXT" placeholder="Kullanıcı adı yazınız." runat="server" CssClass="ayarlarTXT" Font-Bold="True" ValidationGroup="kadi"></asp:TextBox>
                    </td>
                    <td style="vertical-align:middle;padding-top:2px;">
                        <asp:Button ID="Button2" runat="server" Text="Güncelle" CssClass="kaydetBTN" OnClick="kadiGuncelleBTN_Click" ValidationGroup="kadi" />
                    </td>
                </tr>
            </table>

        </div>
      </div>
      <div class="AccordionPanel">
        <div class="AccordionPanelTab">Şifre Güncelle</div>
        <div class="AccordionPanelContent">

            <table border="0" style="width:100%;">
                <tr>
                    <td>
                        <asp:TextBox ID="mevcut" placeholder="Mevcut Şifre" runat="server" CssClass="ayarlarFullTXT" Font-Bold="True" TextMode="Password" ValidationGroup="sifre"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ySifre" placeholder="Yeni Şifre" runat="server" CssClass="ayarlarFullTXT" Font-Bold="True" TextMode="Password" ValidationGroup="sifre"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tSifre" placeholder="Yeni Şifre Tekrarı" runat="server" CssClass="ayarlarFullTXT" Font-Bold="True" TextMode="Password" ValidationGroup="sifre"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:HiddenField ID="sifre" runat="server" />
                        <asp:Button ID="sifreGuncelleBTN" runat="server" Text="Güncelle" CssClass="kaydetBTN" OnClick="sifreGuncelleBTN_Click" ValidationGroup="sifre" />
                    </td>
                </tr>
            </table>

        </div>
      </div>
      <div class="AccordionPanel">
        <div class="AccordionPanelTab">İletişim Bilgileri Güncelle</div>
        <div class="AccordionPanelContent">

            <table border="0" style="width:100%;">
                <tr>
                    <td>
                        <asp:TextBox ID="telTXT" placeholder="Telefon numaranızı yazınız." runat="server" CssClass="ayarlarFullTXT" Font-Bold="True" ValidationGroup="iletisim"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="postaTXT" placeholder="E-Posta yazınız." runat="server" CssClass="ayarlarFullTXT" Font-Bold="True" ValidationGroup="iletisim"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="iletisimGuncelleBTN" runat="server" Text="Güncelle" CssClass="kaydetBTN" OnClick="iletisimGuncelleBTN_Click" ValidationGroup="iletisim" />
                    </td>
                </tr>
            </table>

        </div>
      </div>
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1");
    </script>

</asp:Content>
