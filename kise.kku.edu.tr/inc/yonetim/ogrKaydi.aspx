<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrKaydi.aspx.cs" Inherits="inc_yonetim_ogrKaydi" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td style="width:150px;">
           <h3>Öğrenci Kayıtları</h3> 
        </td>
        <td style="width:91px; height:35px; padding-right:2px; text-align:right;">
            <asp:Button ID="ogrenciSilBTN" runat="server" 
                Text="Seçimi Sil" Visible="False" CssClass="silBTN" 
                ValidationGroup="ogrSil" onclick="ogrenciSilBTN_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <div class="listeBG">
            <asp:Button ID="listeleBTN" runat="server" Text="Listele" Width="100%" ValidationGroup="ogrListele" 
                CssClass="listeleBTN" OnClick="listeleBTN_Click" />

            <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" 
                Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                <asp:GridView ID="GridView_ogrenci" DataKeyNames="UserID" 
                    AutoGenerateColumns="False" CellPadding="5" runat="server" CssClass="tabloBaslik" OnSelectedIndexChanged="GridView_ogrenci_SelectedIndexChanged">
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
                        <asp:BoundField HeaderText="Kullanıcı Adı" DataField="UserName" ItemStyle-Width="130px">
                            <ItemStyle CssClass="tabloTD" Width="130px"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Adı" DataField="Name" ItemStyle-Width="110px">
                            <ItemStyle CssClass="tabloTD" Width="110px"></ItemStyle>
                            <HeaderStyle CssClass="tabloBasliklari" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Soyadı" DataField="Surname" ItemStyle-Width="110px">
                            <ItemStyle CssClass="tabloTD" Width="110px"></ItemStyle>
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
