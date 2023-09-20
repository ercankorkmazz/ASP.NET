<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="testler.aspx.cs" Inherits="inc_egitmen_testKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" style="width:920px;">
        <tr>
            <td>
                <h3>Yeni Test</h3>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width:770px;">
                <asp:TextBox ID="testadiTXT" placeholder="Test adını yazınız." Width="770" runat="server" CssClass="standartTXT"></asp:TextBox>
            </td>
            <td style="vertical-align:central;">
                <asp:Button ID="testKaydetBTN" runat="server" Text="Test Oluştur" CssClass="kaydetBTN" Width="140" OnClick="testKaydetBTN_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height:34px;">
                <h3>Sisteme Kayıtlı Testler</h3>
            </td>
            <td align="right">
                <asp:Button ID="testSilBTN" runat="server" 
                    Text="Seçili Testleri Sil" Visible="False" CssClass="silBTN" 
                    ValidationGroup="testSil" OnClick="testSilBTN_Click" Width="140" />
            </td>
        </tr>
   </table>
    <div class="listeBG">
            
        <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" 
            Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

            <asp:GridView ID="GridView_testler" DataKeyNames="id" 
                AutoGenerateColumns="False" CellPadding="5" runat="server" CssClass="tabloBaslik" onselectedindexchanged="GridView_testler_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:CheckBox ID="secim" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="40px">
                        <ItemStyle Width="40px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Test Adı" DataField="testadi">
                        <ItemStyle CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Durumu" DataField="kontrol" ItemStyle-Width="95px">
                        <ItemStyle Width="92px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="gitBTN" ItemStyle-Width="100px" Text="Teste Git"/>
                </Columns>
            </asp:GridView> 
    </div>
</asp:Content>
