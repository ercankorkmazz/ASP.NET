<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenciler.aspx.cs" Inherits="inc_yonetim_ogrKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <table border="0" width="918px">
    <tr>
        <td>
            <h3>Etkinlik Videoları</h3>
        </td>
        <td align="right" colspan="2" style="padding-right:4px;">
            <strong>Seçili Grup:</strong>
            <asp:Label ID="grupAdiTXT" runat="server" Text="Yok" Font-Bold="True" 
                ForeColor="#003366"></asp:Label>
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
        <td align="right" style="padding-right:4px;height:35px;">
            <asp:Button ID="bilgiBTN" runat="server" Text=" " CssClass="bilgiBTN" 
                onclick="bilgiBTN_Click" />
            <asp:Button ID="kaydetBTN" runat="server" Text="Kaydet" CssClass="button" 
                Visible="False" onclick="kaydetBTN_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="vertical-align:top;">
            <div class="listeBG" style="width:550px; vertical-align:top;">
            
                <asp:Label ID="karsilama" runat="server" ForeColor="White" 
                    Text="- Listeleme Yapınız -" CssClass="karsilamaMetni"></asp:Label>

                <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" 
                    Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                <asp:GridView ID="GridView_ogrenci" DataKeyNames="id" 
                    AutoGenerateColumns="False" CellPadding="5" runat="server" Width="550px" CssClass="tabloBaslik" onselectedindexchanged="GridView_ogrenci_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="25px">
                            <ItemStyle Width="25px" CssClass="tabloTD" BackColor="#06151C" BorderWidth="1px"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ad Soyad" DataField="adSoyad">
                            <ItemStyle CssClass="tabloTD"></ItemStyle>
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
                        <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="ogrVideolariBTN" ItemStyle-Width="30px" Text=" "/>
                    </Columns>
                </asp:GridView>           
            
            </div>
        </td>
        <td style="vertical-align:top;">
                <asp:GridView ID="GridView_gruplar" DataKeyNames="id" 
                    AutoGenerateColumns="False" CellPadding="5" runat="server" Width="355px" 
                    CssClass="tabloBaslik" 
                    onselectedindexchanged="GridView_ogrenci_SelectedIndexChanged" Visible="False">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20">
                            <ItemTemplate>
                                <asp:CheckBox ID="secim" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="25px">
                            <ItemStyle Width="25px" CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Gruplar" DataField="grupAdi">
                            <ItemStyle CssClass="tabloTD"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView> 
        </td>
    </tr>
   </table>
</asp:Content>
