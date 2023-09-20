<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="inc_egitmen_test" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="CollapsiblePanel1" class="CollapsiblePanel">
      <div class="CollapsiblePanelTab" tabindex="0">Test Ayarları - Testin görüntülenmesini istediğiniz grupları bu kısımdan ayarlayabilirsiniz.</div>
      <div class="CollapsiblePanelContent">
            <table border="0" style="width:920px;">
                <tr>
                    <td style="width:730px;">
                        <asp:TextBox ID="testadiTXT" placeholder="Test başlığını yazınız." ValidationGroup="baslikGuncelle" Width="730" runat="server" CssClass="standartTXT"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:CheckBox ID="durumu" runat="server" />
                    </td>
                    <td style="padding-right:7px;">Yayınla</td>
                    <td style="vertical-align:top;padding-top:2px;">
                        <asp:Button ID="testGuncelleBTN" runat="server" Text="Güncelle" ValidationGroup="baslikGuncelle" CssClass="kaydetBTN" Width="110" OnClick="testGuncelleBTN_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_gruplar" DataKeyNames="id" 
                            AutoGenerateColumns="False" CellPadding="5" runat="server" Width="730px" 
                            CssClass="tabloBaslik"  Visible="False">
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
                    <td colspan="2" style="text-align:left;vertical-align:central;">
                        <asp:Button ID="bilgiBTN" runat="server" Text=" " CssClass="bilgiBTN" 
                            onclick="bilgiBTN_Click" />
                    </td>
                </tr>
           </table>
        </div>
    </div>
    <table border="0" style="margin-top:10px;width:920px;">
        <tr>
            <td align="center" colspan="3"><b>Çoktan Seçmeli Soru Ekle</b></t>
            <td align="center"><b>Boşluk Doldurma Sorusu Ekle</b></td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="width:500px;">
                    <textarea id="coktanSecSoru" name="coktanSecSoru" class="ckeditor" runat="server"></textarea>
                </div>
            </td>
            <td>
                <div style="width:410px;">
                    <textarea id="boslukDoldurmaSorusu" name="boslukDoldurmaSorusu" class="ckeditor" runat="server"></textarea>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width:40px;">
                <asp:RadioButtonList ID="coktanSecmeliCevaplar" ValidationGroup="cokSecSoru" runat="server">
                    <asp:ListItem Value="1" Text="A"></asp:ListItem>
                    <asp:ListItem Value="2" Text="B"></asp:ListItem>
                    <asp:ListItem Value="3" Text="C"></asp:ListItem>
                    <asp:ListItem Value="4" Text="D"></asp:ListItem>
                    <asp:ListItem Value="5" Text="E"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="width:300px;">
                <table border="0" style="width:300px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="secenek1" placeholder="A seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="300" runat="server" CssClass="cevapTXT"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="secenek2" placeholder="B seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="300" runat="server" CssClass="cevapTXT"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="secenek3" placeholder="C seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="300" runat="server" CssClass="cevapTXT"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="secenek4" placeholder="D seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="300" runat="server" CssClass="cevapTXT"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="secenek5" placeholder="E seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="300" runat="server" CssClass="cevapTXT"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:150px;padding-top:4px;" valign="top">
                <asp:Button ID="coktanSecKaydetBTN" runat="server" Text="Soruyu Kaydet" ValidationGroup="cokSecSoru" CssClass="kaydetBTN" Width="150" OnClick="coktanSecKaydetBTN_Click" />
            </td>
            <td valign="top" style="padding-top:4px;">
                <asp:TextBox ID="boslukDoldurCevabi" placeholder="Sorudaki boşluğu buraya yazınız." ValidationGroup="cokSecSoru" Width="410" runat="server" CssClass="cevapTXT"></asp:TextBox>
                <div style="margin-top:5px; text-align:right;">
                    <asp:Button ID="boslukDoldurBTN" runat="server" Text="Soruyu Kaydet" ValidationGroup="cokSecSoru" CssClass="kaydetBTN" Width="150" OnClick="boslukDoldurBTN_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center"><b>Doğru / Yanlış Sorusu Ekle</b></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="width:500px;">
                    <textarea id="dogruYanlisSorusu" placeholder="Soruyu bu alana yazınız." name="boslukDoldurmaSorusu" class="ckeditor" runat="server"></textarea>
                </div>
            </td>
            <td valign="center">&nbsp;
                
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:RadioButtonList ID="dogruYanlisCevap" ValidationGroup="dogruYanlisSorusu" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="Doğru"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Yanlış"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="dogruYanlisKaydet" runat="server" Text="Soruyu Kaydet" ValidationGroup="dogruYanlisSorusu" CssClass="kaydetBTN" Width="150" OnClick="dogruYanlisKaydet_Click" />
            </td>
        </tr>
    </table>
    <table border="0" style="margin-top:15px;">
        <tr>
            <td style="height:37px;">
                <h3>Teste Kayıtlı Sorular</h3>
            </td>
            <td align="right">
                <asp:Button ID="soruSilBTN" runat="server" 
                    Text="Seçili Soruları Sil" CssClass="silBTN" 
                    ValidationGroup="soruSil" Width="140" OnClick="soruSilBTN_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
            <div class="listeBG">
                <asp:Label ID="sorguSonucuSorular" runat="server" ForeColor="White" Visible="False"
                    Text="Hiçbir kayıt bulunamadı." CssClass="karsilamaMetni"></asp:Label>

                    <asp:GridView ID="GridView_sorular" DataKeyNames="id"  onselectedindexchanged="GridView_sorular_SelectedIndexChanged"
                        AutoGenerateColumns="False" CellPadding="5" runat="server"  CssClass="tabloBaslik">
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
                            <asp:BoundField HeaderText="Soru" DataField="soru" 
                                ItemStyle-Width="380px" >
                                <ItemStyle Width="380px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Cevap" DataField="cevap">
                                <ItemStyle CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Yanıt" DataField="yanit" 
                                ItemStyle-Width="190px" >
                                <ItemStyle Width="50px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Soru Türü" DataField="turu" 
                                ItemStyle-Width="120px" >
                                <ItemStyle Width="120px" CssClass="tabloTD"></ItemStyle>
                                <HeaderStyle CssClass="tabloBasliklari" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="gitBTN" ItemStyle-Width="100px" Text="Soruya Git"/>
                        </Columns>
                    </asp:GridView>            
            
                </div>    
            </td>
        </tr>
    </table>
    
    <script type="text/javascript">
        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1");
    </script>
</asp:Content>
