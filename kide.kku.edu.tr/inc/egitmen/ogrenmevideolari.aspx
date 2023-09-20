<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenmevideolari.aspx.cs" Inherits="inc_ogrenmeAmacliVideolar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="920px">
        <tr>
            <td>
                <h3>Öğrenme Amaçlı Videolar</h3>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="bilgiTXT" placeholder="Video hakkında kısa bilgi yazınız." runat="server" CssClass="standartTXT"></asp:TextBox>
            </td>
            <td style="vertical-align:top;padding-top:2px;">
                <asp:Button ID="videoKaydetBTN" runat="server" Text="Kaydet" CssClass="kaydetBTN" OnClick="videoKaydetBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Eklemek istediğiniz videonun "<b>Video Yerleştirme Kodunu</b>" aşağıdaki alana Kopyala+Yapıştır yapınız.<br />
            </td>
        </tr>
        <tr>
            <td style="width:700px;">
                <asp:TextBox ID="videoURLTXT" placeholder="Örnek: &lt;iframe width=&quot;420&quot; height=&quot;315&quot; src=&quot;https://www.youtube.com/embed/Mr5wV8uOiy8&quot; frameborder=&quot;0&quot; allowfullscreen&gt;&lt;/iframe&gt;" runat="server" TextMode="MultiLine" CssClass="MultiTXT"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>Youtube videoları için yerleştirme koduna nasıl ulaşırım?</b><br />
                <b>1.)</b> Yerleştirmek istediğiniz YouTube videosuna gidin.<br />
                <b>2.)</b> Videonun altındaki <b>Paylaş</b> butonuna tıklayın.<br />
                <b>3.)</b> Paylaş butonunun altında <b>Ekle</b> butonu belirecek. Ekle butonuna tıklayın. Görüntülenen kutudan HTML kodunu kopyalayın ve aşağıdaki alana yapıştırın.
            </td>
        </tr>
    </table>
    <table border="0" style="width:920px; margin-top:20px;">
        <asp:Repeater ID="rptvideolar" runat="server" OnItemCommand="rptvideolar_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td>
                        <h4><%#Eval("bilgi") %></h4>
                    </td>
                    <td align="right">
                        <asp:Button ID="videoSilBTN" runat="server" Text="Sil" CssClass="sil2BTN" CommandName="videoSilButonlari" CommandArgument='<%#Eval("id") %>' />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%#Eval("video") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
