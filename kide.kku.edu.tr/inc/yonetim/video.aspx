<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="video.aspx.cs" Inherits="inc_yonetim_video" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width:920px;" border="0">
        <%
            baglanti videoSorgu = new baglanti();
            videoSorgu.verileriGetir("select * from ogrencivideo where id='" + Session[Request.Url.Authority + "videoID"] + "' and ogrID='" + Session[Request.Url.Authority + "ogrID"] + "'");
            if (videoSorgu.SQLTablo.Rows.Count > 0)
            {
        %>
            <tr>
                <td colspan="3">
                    <h3 style="float:left;"><% Response.Write(videoSorgu.SQLTablo.Rows[0][2]); %></h3>
                    <asp:Button ID="geriDon" runat="server" Text="Geri Dön" CssClass="geriDonBTN" 
                        onclick="geriDon_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">

                    <div id="player_a" class="projekktor"></div>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            projekktor('#player_a', {
                                poster: '../../images/videoBG.jpg',
                                title: 'this is projekktor',
                                playerFlashMP4: '../../video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                playerFlashMP3: '../../video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                width: 915,
                                height: 510,
                                playlist: [
                                    {
                                        0: { src: "../../video/<% Response.Write(videoSorgu.SQLTablo.Rows[0][3]); %>", type: "video/mp4" }
                                    }
                                ]
                            }, function (player) { } // on ready 
                            );
                        });
                    </script>
                </td>
            </tr>
            
            <asp:Repeater ID="rptYorumlar" OnItemCommand="rptyorumlar_ItemCommand" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="width:25px; border:1px solid #21c80e; background:#fff;">
                            <img src="../../images/ico_author.png" />
                        </td>
                        <td style="width:400px; background:#fff;padding-left:5px; font-weight:bold; color:#4b9b29;">
                            <%#Eval("adSoyad")%>
                        </td>
                        <td align="right">
                            <asp:Button ID="yorumSilBTN" runat="server" Text='Yorumu Sil' 
                                CommandName="yorumSilButonlari"  CommandArgument='<%#Eval("yorumID") %>' 
                                CssClass="yorumSilBTN" />
                        </td>
                    </tr>
                    <tr style="border-top:1px solid #21c80e; background:#fff;">
                        <td class="yorumBG" colspan="3"><%#Eval("yorum")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        <%
            }
            else
                Response.Redirect("~/inc/yonetim/ogrenci.aspx");      
        %>
   </table>
   <center style="margin-top:30px;">
        <strong>Öğrenci:</strong>
        <asp:Label ID="ogrAdiTXT" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
   </center>
</asp:Content>
