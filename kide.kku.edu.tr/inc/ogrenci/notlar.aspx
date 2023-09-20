<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="notlar.aspx.cs" Inherits="inc_ogrenci_notlar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3 align="center">Ders Notları</h3>
    <asp:Label ID="sorguSonucuSorular" runat="server" ForeColor="White" Visible="False"
        Text="Ders Notu Bulunamadı" CssClass="karsilamaMetni"></asp:Label>
    <table border="0" style="width:920px;">
        <asp:Repeater ID="rptnotlar" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="dersNotuBilgisi">
                        <h4><%#Eval("baslik") %></h4>
                    </td>
                </tr>
                <tr>
                    <td class="dersNotuBilgisi">
                        <%#Eval("bilgi") %>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top:5px;">
                        <a href='<%#Eval("dosya","../../dosya/{0}") %>' style="text-decoration:none;">
                            <img src="../../images/indir.png" />
                            Ders notunu indir</a>
                    </td>
                </tr>
                <tr>
                    <td class="dersNotuBilgisi"><hr /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
