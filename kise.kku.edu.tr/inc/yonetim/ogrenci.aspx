<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ogrenci.aspx.cs" Inherits="inc_ogrenci_ogrenmeAmacliVideolar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center><asp:Label ID="adSoyadTXT" runat="server" Text="Öğrenci Adı" Font-Bold="True" Font-Size="20px" ForeColor="#09607f"></asp:Label></center>
    <table border="0" class="performansTable" style="margin-top:15px;width:100%;">
        <tr id="baslikTR" runat="server">
            <td style="width:80px;font-size:16px;color:#01707f;"><strong>TARİH</strong></td>
            <td style="font-size:16px; color:#01707f;"><strong>PROGRAM ADI</strong></td>
            <td colspan="2" style="font-size:16px; color:#01707f;"><strong>BAŞARI</strong></td>
        </tr>
        <asp:Repeater ID="rptperformanslar" runat="server">
            <ItemTemplate>
                    <tr>
                        <td>
                            <strong><%# DataBinder.Eval(Container.DataItem, "Date", "{0:dd.MM.yyyy}")%></strong>
                        </td>
                        <td><strong><%#Eval("ProgramName")%></strong></td>
                        <td style="width:300px;">
                            <div class="expand-bg">
                                <div style="width:100%;"><span class="expand ps" style='width:<%#Convert.ToInt32(Eval("OverallPerformance")) %>%;'>&nbsp;</span></div>
                            </div>
                        </td>
                        <td style="width:60px;"><strong><%#Convert.ToInt32(Eval("OverallPerformance"))%> %</strong></td>
                    </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="clr"></div>
    <asp:Label ID="sorguSonucu" runat="server" Visible="False"
        Text="Performans Kaydı Bulunamadı" CssClass="karsilamaMetni"></asp:Label>
</asp:Content>
