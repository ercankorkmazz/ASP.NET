<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="soru.aspx.cs" Inherits="inc_egitmen_soru" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="geriDon" runat="server" Text="Geri Dön" CssClass="geriDonBTN" OnClick="geriDon_Click" />
    <div class="clr" style="height:10px;"></div>
    <asp:Panel ID="coktanSecmeli" runat="server">
        <textarea id="coktanSecSoru" name="coktanSecSoru" class="ckeditor" runat="server"></textarea>
        <table border="0" style="width:600px; margin-left:auto; margin-right:auto;">
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
                <td style="width:445px;">
                    <table border="0" style="width:445px;">
                        <tr>
                            <td>
                                <asp:TextBox ID="secenek1" placeholder="A seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="445" runat="server" CssClass="cevapTXT"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="secenek2" placeholder="B seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="445" runat="server" CssClass="cevapTXT"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="secenek3" placeholder="C seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="445" runat="server" CssClass="cevapTXT"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="secenek4" placeholder="D seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="445" runat="server" CssClass="cevapTXT"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="secenek5" placeholder="E seçeneğini buraya yazınız." ValidationGroup="cokSecSoru" Width="445" runat="server" CssClass="cevapTXT"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="padding-top:4px;" align="right" valign="top">
                    <asp:Button ID="coktanSecKaydetBTN" runat="server" Text="Güncelle" ValidationGroup="cokSecSoru" CssClass="kaydetBTN" Width="100" OnClick="coktanSecKaydetBTN_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="boslukDolsurma" runat="server">
        <textarea id="boslukDoldurmaSorusu" name="boslukDoldurmaSorusu" class="ckeditor" runat="server"></textarea>
        <table border="0" style="width:600px; margin-left:auto; margin-right:auto;">
            <tr>
                <td>
                    <asp:TextBox ID="boslukDoldurCevabi" placeholder="Sorudaki boşluğu buraya yazınız." ValidationGroup="cokSecSoru" Width="495" runat="server" CssClass="cevapTXT"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Button ID="boslukDoldurBTN" runat="server" Text="Güncelle" ValidationGroup="cokSecSoru" CssClass="kaydetBTN" Width="100" OnClick="boslukDoldurBTN_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="dogruYanlis" runat="server">
        <textarea id="dogruYanlisSorusu" placeholder="Soruyu bu alana yazınız." name="boslukDoldurmaSorusu" class="ckeditor" runat="server"></textarea>
        <table border="0" style="width:900px; margin-left:auto; margin-right:auto;">
            <tr>
                <td align="right">
                    <asp:RadioButtonList ID="dogruYanlisCevap" ValidationGroup="dogruYanlisSorusu" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="Doğru"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Yanlış"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="right" style="padding-left:10px; width:110px;">
                    <asp:Button ID="dogruYanlisKaydet" runat="server" Text="Güncelle" ValidationGroup="dogruYanlisSorusu" CssClass="kaydetBTN" Width="100" OnClick="dogruYanlisKaydet_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
