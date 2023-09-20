<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="egitmenKaydi.aspx.cs" Inherits="inc_yonetim_egitmenKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:925px;">
        <tr>
            <td style="height:35px;"><h3>Eğitmen Kayıtları</h3></td>
            <td align="right">
                <asp:Button ID="egitmenSilBTN" runat="server" 
                    Text="Seçimi Sil" Visible="False" CssClass="silBTN" 
                    ValidationGroup="egitmenSil" onclick="egitmenSilBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="listeBG">
                    
                    <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" Visible="False"
                        Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                    <asp:Button ID="listeleBTN" runat="server" Text="Listele" Width="100%" ValidationGroup="egitmenListele" 
                        CssClass="listeleBTN" onclick="listeleBTN_Click" />

                    <asp:GridView ID="GridView_egitmen" DataKeyNames="UserID" 
                        AutoGenerateColumns="False" CellPadding="5" runat="server" CssClass="tabloBaslik">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="25">
                                <ItemTemplate>
                                    <asp:CheckBox ID="secim" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="UserID" ItemStyle-Width="25px">
                                <ItemStyle Width="25px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Adı" DataField="Name" 
                                ItemStyle-Width="250px" >
                                <ItemStyle Width="250px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Soyadı" DataField="Surname" 
                                ItemStyle-Width="250px" >
                                <ItemStyle Width="250px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="E-Posta" DataField="Email" 
                                ItemStyle-Width="190px" >
                                <ItemStyle Width="190px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Telefon" DataField="PhoneNumber" 
                                ItemStyle-Width="130px" >
                                <ItemStyle Width="130px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Kullanıcı Adı" DataField="UserName" 
                                ItemStyle-Width="250px" >
                                <ItemStyle Width="250px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
