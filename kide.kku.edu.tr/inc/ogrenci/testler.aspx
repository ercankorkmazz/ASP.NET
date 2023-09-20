<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="testler.aspx.cs" Inherits="inc_ogrenci_testler" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" style="width:920px;">
        <tr>
            <td>
                <h3>Testler</h3>
            </td>
        </tr>
   </table>
    <div class="listeBG">
            
        <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" 
            Text="Test bulunamadı." CssClass="karsilamaMetni"></asp:Label>
            <asp:GridView ID="GridView_testler" DataKeyNames="id" 
                AutoGenerateColumns="False" CellPadding="5" runat="server" CssClass="tabloBaslik" onselectedindexchanged="GridView_testler_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="40px">
                        <ItemStyle Width="40px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Test Adı" DataField="testadi">
                        <ItemStyle CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="gitBTN" ItemStyle-Width="100px" Text="Teste Git"/>
                </Columns>
            </asp:GridView> 
    </div>
</asp:Content>
