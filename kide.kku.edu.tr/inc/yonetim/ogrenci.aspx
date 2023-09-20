<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenci.aspx.cs" Inherits="inc_yonetim_ogrenci" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:925px;">
        <tr>
            <td>
                <h3>Yeni Video Ekle</h3>
            </td>
            <td align="right">
                <strong>Öğrenci:</strong>
                <asp:Label ID="ogrAdiTXT" runat="server" Font-Bold="True" 
                    ForeColor="#003366"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="videoBilgi" runat="server" Width="300px" CssClass="formElemanlari" placeholder="Video Başlığı Yazınız"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width:300px;">
                <asp:FileUpload ID="fluDosya" runat="server" Width="100%" CssClass="dosyaYukleyici" />
            </td>
            <td>
                <asp:Button ID="yukleBTN" runat="server" Text="Yükle" CssClass="kaydetBTN"
            onclick="yukleBTN_Click" />
            </td>
        </tr>
    </table>
    <br />
    <table style="width:925px;">
        <tr>
            <td style="height:35px;"><h3>Öğrenci Videoları</h3></td>
            <td align="right">
                <asp:Button ID="videoSilBTN" runat="server" 
                    Text="Seçili Videoları Sil" Visible="False" CssClass="silBTN" 
                    ValidationGroup="egitmenSil" Width="150px" onclick="videoSilBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="listeBG">
                    
                    <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" Visible="False"
                        Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                    <asp:Button ID="listeleBTN" runat="server" Text="Listele" Width="100%" ValidationGroup="videoListele" 
                        CssClass="listeleBTN" onclick="listeleBTN_Click" />

                    <asp:GridView ID="GridView_videolar" DataKeyNames="id" 
                        AutoGenerateColumns="False" CellPadding="5" runat="server"  
                        CssClass="tabloBaslik" 
                        onselectedindexchanged="GridView_ogrenci_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="25">
                                <ItemTemplate>
                                    <asp:CheckBox ID="secim" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="30px">
                                <ItemStyle Width="30px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Öğrencinin Adı Soyadı" DataField="adSoyad" 
                                ItemStyle-Width="170px" >
                                <ItemStyle Width="170px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Başlık" DataField="bilgi">
                                <ItemStyle CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Video" DataField="video" 
                                ItemStyle-Width="200px" >
                                <ItemStyle Width="200px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="ogrVideolariBTN" ItemStyle-Width="30px" Text=" "/>
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
