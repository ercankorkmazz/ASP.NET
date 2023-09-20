<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="notlar.aspx.cs" Inherits="inc_egitmen_notlar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="920px">
        <tr>
            <td>
                <h3>Yeni Ders Notu</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="baslikTXT" placeholder="Ders notu başlığını yazınız." Width="922" runat="server" CssClass="standartTXT"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <textarea id="bilgiTXT" name="boslukDoldurmaSorusu" class="ckeditor" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                Yüklenebilir dosya formatları ( <strong>pdf</strong> , <strong>doc</strong> , <strong>docx</strong> , <strong>xls</strong> , <strong>xlsx</strong> , 
                    <strong>ppt</strong> , <strong>pptx</strong> , <strong>pps</strong> , <strong>ppsx</strong> , <strong>txt</strong> , <strong>rar</strong> )
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="notDosyasi" runat="server" Width="100%" CssClass="dosyaYukleyici" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="kaydetBTN" runat="server" Text="Ders Notunu Kaydet" Width="160" CssClass="kaydetBTN" OnClick="kaydetBTN_Click" />
            </td>
        </tr>
    </table>
    <table style="width:925px;margin-top:20px;">
        <tr>
            <td style="height:35px;"><h3>Ders Notları</h3></td>
            <td align="right">
                <asp:Button ID="dosyaSilBTN" runat="server" 
                    Text="Seçili Ders Notlarını Sil" Visible="False" CssClass="silBTN" 
                    ValidationGroup="egitmenSil" Width="160px" OnClick="dosyaSilBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="listeBG">
                    
                    <asp:Label ID="sorguSonucu" runat="server" ForeColor="White" Visible="False"
                        Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                    <asp:GridView ID="GridView_dosyalar" DataKeyNames="id" 
                        AutoGenerateColumns="False" CellPadding="5" runat="server"  
                        CssClass="tabloBaslik" OnSelectedIndexChanged="GridView_dosyalar_SelectedIndexChanged" >
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
                            <asp:BoundField HeaderText="Başlık" DataField="baslik">
                                <ItemStyle CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Dosya" DataField="dosya" ItemStyle-Width="170px">
                                <ItemStyle Width="170px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="indirBTN" ItemStyle-Width="30px" Text=" "/>
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
