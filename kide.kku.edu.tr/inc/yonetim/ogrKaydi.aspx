<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrKaydi.aspx.cs" Inherits="inc_yonetim_ogrKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:925px;">
        <tr>
            <td style="width:300px;"><h3>Yeni Öğrenci</h3></td>
            <td style="width:190px;">&nbsp;</td>
            <td colspan="3"><h3>Yeni Grup</h3></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="ogrenciAdiTXT" runat="server" Width="294px"
                    placeholder="Öğrencinin Adı Soyadı" ValidationGroup="ogrEkle" 
                    CssClass="formElemanlari"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="yeniGrupTXT" runat="server" Width="291px" 
                    placeholder="Yeni grup adını yazınız." ValidationGroup="grupEkle" 
                    CssClass="formElemanlari"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Button ID="grupEkleBTN" runat="server" Text="Kaydet" 
                    ValidationGroup="grupEkle" onclick="grupEkleBTN_Click" 
                    CssClass="kaydetBTN" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="gruplarDropDownList" runat="server" BorderColor="#000066" 
                    BorderStyle="Inset" BorderWidth="1px" 
                    Width="100%" ValidationGroup="ogrEkle" CssClass="formElemanlari">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td colspan="3"><h3>Grup Sil / Güncelle</h3></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="ogrEkleBTN" runat="server" Text="Kaydet" 
                    ValidationGroup="ogrEkle" onclick="ogrEkleBTN_Click" 
                    CssClass="kaydetBTN" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="grupAdiGuncelleDropDownList" runat="server" 
                    BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" 
                    Width="100%" ValidationGroup="grupAdiGuncelle" CssClass="formElemanlari">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                <asp:Button ID="grupSecBTN" runat="server" Text="Grubu Seç" 
                    Width="100%" onclick="grupSecBTN_Click" ValidationGroup="grupAdiGuncelle" 
                    CssClass="secBTN" />
            </td>
        </tr>
        <tr>
            <td><asp:HiddenField ID="grupID" runat="server" /></td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="grupAdiTXT" runat="server" Width="291px" 
                    placeholder="Grup seçiniz." ValidationGroup="grupSil" 
                    CssClass="formElemanlari"></asp:TextBox>
            </td>
            <td style="width:65px;">
                <asp:Button ID="grupSilBTN" runat="server" Text="Sil" ValidationGroup="grupSil" Width="100%" onclick="grupSilBTN_Click" 
                    CssClass="sil2BTN" />
            </td>
            <td style="width:110px;">
                <asp:Button ID="grupGuncelleBTN" runat="server" Text="Güncelle" 
                    ValidationGroup="grupSil" onclick="grupGuncelleBTN_Click" 
                    CssClass="guncelle2BTN" Width="100%" />
            </td>
        </tr>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
   </table>
   <table border="0" width="100%">
    <tr>
        <td colspan="5">
            <h3>Öğrenci Bilgileri / Videoları</h3>
        </td>
    </tr>
    <tr>
        <td style="width:150px;">
            <asp:DropDownList ID="gruplarListeleDropDownList" runat="server" 
                BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px"
                Width="150px" ValidationGroup="ogrListele" CssClass="formElemanlari">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="grubaGoreListeleBTN" runat="server" Text="Listele" 
                onclick="grubaGoreListeleBTN_Click" ValidationGroup="ogrListele" 
                CssClass="listeleBTN" />
        </td>
        <td align="right">
            <asp:DropDownList ID="grupGuncelleDropDownList" runat="server" 
                BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px"
                Width="150px" Visible="False" ValidationGroup="grupGuncelle" 
                CssClass="formElemanlari">
            </asp:DropDownList>
        </td>
        <td style="text-align:right;width:190px;">
            <asp:Button ID="grupGuncelle" runat="server" 
                Text="Seçimin Grubunu Güncelle" onclick="grupGuncelle_Click" 
                Visible="False" CssClass="guncelleBTN" ValidationGroup="grupGuncelle" />
        </td>
        <td style="width:91px;padding-right:2px;">
            <asp:Button ID="ogrenciSilBTN" runat="server" 
                Text="Seçimi Sil" Visible="False" CssClass="silBTN" 
                ValidationGroup="ogrSil" onclick="ogrenciSilBTN_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="5">
        <div class="listeBG">
            
            <asp:Label ID="karsilama" runat="server" ForeColor="White" 
                Text="- Sorgulama Yapınız -" CssClass="karsilamaMetni"></asp:Label>

            <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" 
                Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

            <asp:GridView ID="GridView_ogrenci" DataKeyNames="id" 
                AutoGenerateColumns="False" CellPadding="5" runat="server"  CssClass="tabloBaslik" onselectedindexchanged="GridView_ogrenci_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="25">
                        <ItemTemplate>
                            <asp:CheckBox ID="secim" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="25px">
                        <ItemStyle Width="35px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="KID" DataField="kullaniciID" ItemStyle-Width="25px">
                        <ItemStyle Width="35px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Grup" DataField="grupAdi" ItemStyle-Width="150px">
                        <ItemStyle Width="150px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ad Soyad" DataField="adSoyad" 
                        ItemStyle-Width="170px" >
                        <ItemStyle Width="170px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Telefon" DataField="telefon" 
                        ItemStyle-Width="110px" >
                        <ItemStyle Width="110px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="e-Posta" DataField="eposta" 
                        ItemStyle-Width="130px" >
                        <ItemStyle Width="130px" CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Kullanıcı Adı" DataField="kadi">
                        <ItemStyle CssClass="tabloTD"></ItemStyle>
                        <HeaderStyle CssClass="tabloBasliklari" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Şifre" DataField="sifre" >
                        <HeaderStyle CssClass="tabloBasliklari" />
                        <ItemStyle CssClass="tabloTD"></ItemStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="ogrVideolariBTN" ItemStyle-Width="30px" Text=" "/>
                </Columns>
            </asp:GridView>            
            
        </div>
        </td>
    </tr>
   </table>
</asp:Content>
