<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="inc_ogrenci_test" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script>
        var dogruu = 0;
        var yanlis = 0;
        var cevaplananlar = new Array();
        
        function secim(id, secenek) {
            var dogru = document.getElementById('cevap' + id).value;
            
            if(cevaplananlar.length == 0)
            {
                cevaplananlar.push(id);
                if (secenek == dogru) {
                    dogruu++;
                    document.getElementById('cevap' + id + "_" + dogru).style.backgroundColor = "#009600";
                    document.getElementById('cevap' + id + "_" + dogru).style.backgroundImage = "url('../../images/dogru.png')";
                }
                else {
                    yanlis++; 
                    document.getElementById('cevap' + id + "_" + dogru).style.backgroundColor = "#009600";
                    document.getElementById('cevap' + id + "_" + dogru).style.backgroundImage = "url('../../images/dogru.png')";
                    document.getElementById('cevap' + id + "_" + secenek).style.backgroundColor = "#ac0000";
                    document.getElementById('cevap' + id + "_" + secenek).style.backgroundImage = "url('../../images/yanlis.png')";
                }
            }
            else if(cevaplananlar.length > 0)
            {
                if(cevaplananlar.indexOf(id) == -1)
                {
                    cevaplananlar.push(id);
                    if (secenek == dogru) {
                        dogruu++;
                        document.getElementById('cevap' + id + "_" + dogru).style.backgroundColor = "#009600"; 
                        document.getElementById('cevap' + id + "_" + dogru).style.backgroundImage = "url('../../images/dogru.png')";
                    }
                    else {
                        yanlis++;
                        document.getElementById('cevap' + id + "_" + dogru).style.backgroundColor = "#009600";
                        document.getElementById('cevap' + id + "_" + dogru).style.backgroundImage = "url('../../images/dogru.png')";
                        document.getElementById('cevap' + id + "_" + secenek).style.backgroundColor = "#ac0000";
                        document.getElementById('cevap' + id + "_" + secenek).style.backgroundImage = "url('../../images/yanlis.png')";
                    }
                }
            }
        }
        function dySecim(id, secenek) {
            var dogru = document.getElementById('dyCevap' + id).value;
            
            if(cevaplananlar.length == 0)
            {
                cevaplananlar.push(id);
                if (secenek == dogru) {
                    dogruu++;
                    document.getElementById('dySonuc' + id).style.background = "#009600 url('../../images/dogru.png') no-repeat center center";
                }
                else {
                    yanlis++;
                    document.getElementById('dySonuc' + id).style.background = "#ac0000 url('../../images/yanlis.png') no-repeat center center";
                }
            }
            else if(cevaplananlar.length > 0)
            {
                if(cevaplananlar.indexOf(id) == -1)
                {
                    cevaplananlar.push(id);
                    if (secenek == dogru) {
                        dogruu++;
                        document.getElementById('dySonuc' + id).style.background = "#009600 url('../../images/dogru.png') no-repeat center center";
                    }
                    else {
                        yanlis++;
                        document.getElementById('dySonuc' + id).style.background = "#ac0000 url('../../images/yanlis.png') no-repeat center center";
                    }
                }
            }
        }
        function cevapla(id, dogru) {
            var cevap = document.getElementById('cevap' + id).value;
            if(cevap != "")
            {
                if(cevaplananlar.length == 0)
                {
                    cevaplananlar.push(id);
                    if (cevap.toLowerCase() == dogru.toLowerCase()) {
                        dogruu++;
                        document.getElementById('cevap' + id).style.backgroundColor = "#090";
                        document.getElementById('cevap' + id).style.color = "#fff";
                    }
                    if (cevap.toLowerCase() != dogru.toLowerCase()) {
                        yanlis++;
                        document.getElementById('cevap' + id).style.backgroundColor = "#ac0000";
                        document.getElementById('cevap' + id).style.color = "#fff";
                    }
                }
                else if(cevaplananlar.length > 0)
                {
                    if(cevaplananlar.indexOf(id) == -1)
                    {
                        cevaplananlar.push(id);
                        if (cevap.toLowerCase() == dogru.toLowerCase()) {
                            dogruu++;
                            document.getElementById('cevap' + id).style.backgroundColor = "#090";
                            document.getElementById('cevap' + id).style.color = "#fff";
                        }
                        if (cevap.toLowerCase() != dogru.toLowerCase()) {
                            yanlis++;
                            document.getElementById('cevap' + id).style.backgroundColor = "#ac0000";
                            document.getElementById('cevap' + id).style.color = "#fff";
                        }
                    }
                }
            }
        }
        function sonuc() {
            var toplam = dogruu + yanlis;

            var yuzdeD = 100 * dogruu / toplam;

            if(toplam!=0)
                alert("Doğru sayısı: "+dogruu+"\nYanlış sayısı:"+yanlis+"\n\n Başarı yüzdeniz: %"+yuzdeD.toFixed(1));
        }
    </script>
    <style>
        td {
	        -moz-border-radius:3px;
	        border-radius:3px;
        }
    </style>
    <center><asp:Label ID="baslik" runat="server" Text="Label" Font-Size="13" Font-Bold="True"></asp:Label></center>
    <table style="width:700px;margin-left:100px;" border="0" cellspacing="0">
        <asp:Repeater ID="rptCoktanSecmeli" runat="server" onitemdatabound="rptCoktanSecmeli_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td colspan="2" style="padding-left:33px;">
                        <h4><%#Eval("soru") %></h4>
                        <input type="hidden" name="link" id='<%#Eval("id","cevap{0}") %>' value='<%#Eval("yanit") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="width:60px;">
                        <table style="width:60px;">
                            <tr>
                              <td id="cevap<%#Eval("id") %>_1" style="width:30px;">&nbsp;</td>
                              <td>
                                  <input onclick="secim('<%#Eval("id") %>','1')" type="radio" name="cevap<%#Eval("id") %>" value="1" />
                                  <label style="color:#f00;">A</label>
                              </td>
                            </tr>
                            <tr>
                              <td id="cevap<%#Eval("id") %>_2" style="width:30px;">&nbsp;</td>
                              <td>
                                  <input onclick="secim('<%#Eval("id") %>','2')" type="radio" name="cevap<%#Eval("id") %>" value="2" />
                                  <label style="color:#f00;">B</label>
                              </td>
                            </tr>
                            <tr>
                              <td id="cevap<%#Eval("id") %>_3" style="width:30px;">&nbsp;</td>
                              <td>
                                  <input onclick="secim('<%#Eval("id") %>','3')" type="radio" name="cevap<%#Eval("id") %>" value="3" />
      	                          <label style="color:#f00;">C</label>
                            </tr>
                            <tr>
                              <td id="cevap<%#Eval("id") %>_4" style="width:30px;">&nbsp;</td>
                              <td>
                                  <input onclick="secim('<%#Eval("id") %>','4')" type="radio" name="cevap<%#Eval("id") %>" value="4" />
                                  <label style="color:#f00;">D</label>
                              </td>
                            </tr>
                            <tr>
                              <td id="cevap<%#Eval("id") %>_5" style="width:30px;">&nbsp;</td>
                              <td>
                                  <input onclick="secim('<%#Eval("id") %>','5')" type="radio" name="cevap<%#Eval("id") %>" value="5" />
                                  <label style="color:#f00;">E</label>
                              </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table width="100%">
                            <asp:Repeater ID="RepeaterCevaplar" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td style="padding-top:1px;padding-bottom:9px;"><%#Eval("yanit") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table style="width:700px;margin-left:100px;margin-top:20px;" border="0" cellspacing="0">
        <asp:Repeater ID="rptDogruYanlis" runat="server">
            <ItemTemplate>
                <tr>
                    <td id="<%#Eval("id","dySonuc{0}") %>" style="width:30px;">&nbsp;</td>
                    <td style="width:40px; height:15px; border-top:1px solid #d3d3d3; border-bottom:1px solid #d3d3d3;">
                        <input onclick="dySecim('<%#Eval("id") %>','1')" value="1" type="radio" name="dogruYanlis<%#Eval("id") %>" />
                        <label style="color:#f00;">D</label>
                        <br />

                        <input onclick="dySecim('<%#Eval("id") %>','2')" value="2" type="radio" name="dogruYanlis<%#Eval("id") %>" />
                        <label style="color:#f00;">Y</label>
                        <br />
                    </td>
                    <td class="dogruYanlis">
                        <strong><%#Eval("soru") %></strong>
                        <input type="hidden" name="link" id='<%#Eval("id","dyCevap{0}") %>' value='<%#Eval("yanit") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table style="width:700px;margin-left:100px;margin-top:20px;" border="0" cellspacing="0">
        <asp:Repeater ID="rptBoslukDoldur" runat="server">
            <ItemTemplate>
                <tr>
                    <td colspan="2" style="padding-left:30px;">
                        <h4><%#Eval("soru") %></h4>
                    </td>
                </tr>
                <tr>
                    <td style="width:400px;padding-left:30px;">
                        <input type="text" name="cevap" id='<%#Eval("id","cevap{0}") %>' placeholder="Cevap yazınız." Class="standartTXT" />
                    </td>
                    <td>
                        <input type="button" value="Cevapla" onclick="cevapla('<%#Eval("id") %>','<%#Eval("cevap") %>')" Class="button" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <center><input type="button" onclick="sonuc()" value="Durum Analizi Yap" Class="button" style=" margin-top:15px;" /></center>
</asp:Content>
