<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="video.aspx.cs" Inherits="inc_ogrenci_video" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="sorguSonucuSorular" runat="server" ForeColor="White" Visible="False"
        Text="Listelenecek Performans Bulunamadı" CssClass="karsilamaMetni"></asp:Label>
        <asp:Repeater ID="rptDigerVideolar" runat="server" OnItemCommand="rptvideolar_ItemCommand" onitemdatabound="rptvideolar_ItemDataBound">
            <ItemTemplate>
                <table style="width:1000px; margin-left:-80px;" border="0" cellspacing="0">
                    <tr>
                        <td style="width:300px;" valign="top"> 
                            <h4 style="border-bottom:2px solid #000;padding-bottom:17px;">Açıklamalar</h4>
                            <%#Eval("aciklamalar")%>
                        </td>
                        <td>
                            <table style="width:700px;" border="0" cellspacing="0">
                                <tr>
                                    <td colspan="2">
                                        <h4 style="float:left;"><%#Eval("bilgi") %></h4>
                                    </td>
                                    <td>
                                        <h4 style="float:right;"><%#Eval("adSoyad") %></h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="padding-bottom:10px;">

                                        <div id='<%#Eval("id","player_{0}") %>' class="projekktor"></div>

                                        <script type="text/javascript">
                                            $(document).ready(function () {
                                                projekktor('<%#Eval("id","#player_{0}") %>', {
                                                    poster: '../../images/videoBG.jpg',
                                                    title: 'this is projekktor',
                                                    playerFlashMP4: '../../video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                                    playerFlashMP3: '../../video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                                    width: 700,
                                                    height: 392,
                                                    playlist: [
                                                        {
                                                            0: { src: "../../video/<%#Eval("video") %>", type: "video/mp4" }
                                                        }
                                                    ]
                                                }, function (player) { } // on ready 
                                                );
                                            });
                                        </script>
                                    </td>
                                </tr>
                                <asp:Repeater ID="RepeaterYorumlar" OnItemCommand="rptyorumlar_ItemCommand" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width:25px; border:1px solid #2281a4; background:#fff;">
                                                <img src="../../images/ico_author.png" />
                                            </td>
                                            <td style="width:400px; background:#fff;padding-left:5px; font-weight:bold; color:#2281a4;">
                                                <%#Eval("adSoyad")%>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="Button1" runat="server" Text='Yorumu Sil' 
                                                    CommandName="yorumSilButonlari"  CommandArgument='<%#Eval("yorumID") %>' 
                                                    CssClass="yorumSilBTN" />
                                            </td>
                                        </tr>
                                        <tr style="border-top:1px solid #2281a4; background:#fff;">
                                            <td class="yorumBG" colspan="3"><%#Eval("yorum")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox ID="yorumTXT" placeholder="Yorum yazınız..." runat="server" TextMode="MultiLine" CssClass="yorumKutusu"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="right">
                                        <asp:Button ID="yorumKayitBTN" runat="server" Text='Yorum Yap' CommandName="yorumButonlari" CommandArgument='<%#Eval("id","{0}") %>' CssClass="yorumGonderBTN" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
         
     
 
</asp:Content>
