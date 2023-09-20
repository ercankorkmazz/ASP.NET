<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BGrubu.aspx.cs" Inherits="inc_ogrenci_videoB" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="tablar">
        <div class="tabSol">
            <a href="../../inc/ogrenci/AGrubu.aspx">
                <img src="../../images/adam.png" />
                <h4>A Grubu</h4>
            </a>
        </div>
        <div class="tabSag" style="background:#4ec9d4;">
            <a href="../../inc/ogrenci/BGrubu.aspx">
                <img src="../../images/adam.png" />
                <h4>B Grubu</h4>
            </a>
        </div>
        <div id="Baslik" class="videoBasligi">&nbsp;</div>
        <div class="clearfix"></div>   
    </div>
        <asp:Repeater ID="rptDigerVideolar" runat="server" OnItemCommand="rptvideolar_ItemCommand" onitemdatabound="rptvideolar_ItemDataBound">
            <ItemTemplate>
                <table style="width:1000px; margin-left:-80px;" border="0" cellspacing="0">
                    <tr>
                        <td style="width:300px;" valign="top"> 
                            <table style="width:100%;" border="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Repeater ID="rptVideoGitButonlari"  OnItemCommand="rptVideoGitButonlari_ItemCommand" runat="server">
                                            <ItemTemplate>
                                                <asp:Button ID="videoGitBTN" runat="server" Text='<%#Eval("bilgi") %>' CommandName="videoGitButonlari" CommandArgument='<%#Eval("id","{0}") %>' CssClass="videoGetirBTN" />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding:7px;">
                                        <h4 style="border-bottom:2px solid #000;">Açıklamalar</h4>
                                        <%#Eval("aciklamalar")%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <form name="FormBaslik">
	                            <input type="hidden" id="hiddenBaslik" value='<%#Eval("bilgi") %>' />
                            </form>
                            <script type="text/javascript">
                                var baslik = document.getElementById("hiddenBaslik")
                                document.getElementById("Baslik").innerHTML = baslik.value;
                            </script>
                            <table style="width:700px;" border="0" cellspacing="0">
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
                                        <asp:Button ID="yorumKayitBTN" runat="server" Text='Yorum Yap' CommandName="yorumButonlari" CommandArgument='<%#Eval("ogrID","{0}") %>' CssClass="yorumGonderBTN" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
         
     
 
</asp:Content>
