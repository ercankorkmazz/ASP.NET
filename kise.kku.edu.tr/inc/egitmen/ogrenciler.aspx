<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenciler.aspx.cs" Inherits="inc_yonetim_ogrKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td>
            <h3>Öğrenci Performansları</h3>
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top;">
            <div class="listeBG" style="width:100%; vertical-align:top;">
                <asp:Button ID="listeleBTN" runat="server" Text="Listele" Width="100%"
                    ValidationGroup="ogrListele" CssClass="listeleBTN" OnClick="listeleBTN_Click" />

                <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" Width="100%"
                    Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                <asp:GridView ID="GridView_ogrenci" DataKeyNames="UserID" 
                    AutoGenerateColumns="False" CellPadding="5" runat="server" CssClass="tabloBaslik" OnSelectedIndexChanged="GridView_ogrenci_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="UserID" DataField="UserID" ItemStyle-Width="25px">
                            <ItemStyle Width="25px" CssClass="tabloTD" BackColor="#06151C" BorderWidth="1px"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Adı" DataField="Name">
                            <ItemStyle CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Soyadı" DataField="Surname">
                            <ItemStyle CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="TC Kimlik No" DataField="IDNumber" ItemStyle-Width="120px">
                            <ItemStyle CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle Width="120px" CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Telefon" DataField="PhoneNumber" 
                            ItemStyle-Width="120px">
                            <ItemStyle Width="120px" CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="E-Posta" DataField="Email" 
                            ItemStyle-Width="250px">
                            <ItemStyle Width="250px" CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="gitBTN" ItemStyle-Width="180px" Text=" Öğrenci Performansları"/>
                    </Columns>
                </asp:GridView>           
            
            </div>
        </td>
    </tr>
   </table>
</asp:Content>
