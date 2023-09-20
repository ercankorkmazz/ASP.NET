<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenmevideolari.aspx.cs" Inherits="inc_ogrenci_ogrenmeAmacliVideolar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3 align="center">Öğrenme Amaçlı Videolar</h3>
    <asp:Label ID="sorguSonucuSorular" runat="server" ForeColor="White" Visible="False"
        Text="Öğrenme Amaçlı Video Bulunamadı" CssClass="karsilamaMetni"></asp:Label>
    <table border="0" style="width:920px;">
        <asp:Repeater ID="rptvideolar" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <h4><%#Eval("bilgi") %></h4>
                    </td>
                    <td align="right">
                        &nbsp;
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
