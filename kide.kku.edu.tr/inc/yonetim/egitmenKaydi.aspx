<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="egitmenKaydi.aspx.cs" Inherits="inc_yonetim_egitmenKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:925px;">
        <tr>
            <td colspan="2"><h3>Yeni Eğitmen</h3></td>
        </tr>
        <tr>
            <td style="width:250px;">
                <asp:TextBox ID="egitmenAdiTXT" runat="server" Width="250px"
                    placeholder="Eğitmenin Adı Soyadı" ValidationGroup="egitmenEkle" 
                    CssClass="formElemanlari"></asp:TextBox>
            </td>
            <td>
               <asp:Button ID="egitmenEkleBTN" runat="server" Text="Kaydet" 
                    ValidationGroup="egitmenEkle"
                    CssClass="kaydetBTN" onclick="egitmenEkleBTN_Click" /> 
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="height:35px;"><h3>Sisteme Kayıtlı Eğitmenler</h3></td>
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
                        CssClass="listeleBTN" onclick="grubaGoreListeleBTN_Click" />

                    <asp:GridView ID="GridView_egitmen" DataKeyNames="id" 
                        AutoGenerateColumns="False" CellPadding="5" runat="server"  CssClass="tabloBaslik">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="25">
                                <ItemTemplate>
                                    <asp:CheckBox ID="secim" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="25px">
                                <ItemStyle Width="25px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Ad Soyad" DataField="adSoyad" 
                                ItemStyle-Width="250px" >
                                <ItemStyle Width="250px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Telefon" DataField="telefon" 
                                ItemStyle-Width="130px" >
                                <ItemStyle Width="130px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="e-Posta" DataField="eposta" 
                                ItemStyle-Width="190px" >
                                <ItemStyle Width="190px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Kullanıcı Adı" DataField="kadi" >
                                <ItemStyle CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Şifre" DataField="sifre" >
                                <ItemStyle CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
