<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrVideolari.aspx.cs" Inherits="inc_egitmen_ogrVideolari" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:100%;" border="0" cellspacing="0">
        <tr>
            <td style="padding:0 0 0 7px;">
                <strong>Öğrenci:</strong>
                <asp:Label ID="ogrAdiTXT" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
            </td>
            <td style="padding:0 7px 0 0;">
                <asp:Button ID="geriDon" runat="server" Text="Geri Dön" CssClass="geriDonBTN" 
        onclick="geriDon_Click" />
            </td>
        </tr>        
        <tr>
            <td colspan="2" style="padding:0;">
                <hr style="margin-top:10px; margin-bottom:10px;" />
            </td>
        </tr>
   </table>
   <asp:Repeater ID="rptDigerVideolar" runat="server" OnItemCommand="rptvideolar_ItemCommand">
            <ItemTemplate>
                <asp:Button ID="yorumKayitBTN" runat="server" Text='<%#Eval("bilgi") %>' CommandName="yorumButonlari" CommandArgument='<%#Eval("id","{0}") %>' CssClass="videoGetirBTN" />
            </ItemTemplate>
   </asp:Repeater>
 
</asp:Content>
