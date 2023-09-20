<%@ Page Title="Sorgula" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="sorgula.aspx.cs" Inherits="sorgula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">

        .style2
        {
            width: 186px;
        }
        .style3
        {
            width: 48px;
        }
        .style5
        {
            width: 147px;
        }
        .style6
        {
            height: 21px;
            width: 147px;
        }
        .style7
        {
            width: 136px;
        }
        .style8
        {
            height: 21px;
            width: 136px;
        }
        .style14
        {
            width: 81px;
        }
        .style15
        {
            height: 21px;
            width: 81px;
        }
        .style16
        {
            width: 113px;
        }
        .style17
        {
            height: 21px;
            width: 113px;
        }
        .style18
        {
            height: 21px;
            width: 123px;
        }
        .style19
        {
            width: 123px;
        }
        .style20
        {
            width: 640px;
        }
        .style21
        {
            height: 21px;
        }
        .style22
        {
            height: 21px;
            width: 73px;
        }
        .style23
        {
            width: 73px;
        }
        .style24
        {
            height: 21px;
            width: 24px;
        }
        .style25
        {
            width: 24px;
        }
        .style26
        {
            height: 21px;
            width: 96px;
        }
        .style27
        {
            width: 96px;
        }
        .style30
        {
            height: 21px;
            width: 54px;
        }
        .style31
        {
            width: 54px;
        }
        .style32
        {
            height: 21px;
            width: 4px;
        }
        .style33
        {
            width: 4px;
        }
        .style34
        {
            width: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td style="width:40%;"><h2>Sorgula</h2></td>
        <td align="right" class="style20">
            &nbsp;<asp:Label ID="bilgiTXT" 
                runat="server" Font-Bold="True" 
            ForeColor="Black" style="text-align: left" CssClass="bilgi" Font-Size="14px"></asp:Label>
        </td>
        <td align="left" style="width:25px;">
            <asp:Panel ID="bilgiIMG" runat="server">
                <img src="../img/bilgi.png"/>
            </asp:Panel>
        </td>
    </tr>
   </table>
    <table style="width:100%; margin-left: -3px; margin-right: 0; margin-top: 10px;">
        <tr>
            <td class="style34">
                    <asp:DropDownList ID="tabloSelect" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="90px" BackColor="#3ed4dd">
                        <asp:ListItem Value="1">Öğrenci</asp:ListItem>
                        <asp:ListItem Value="2">Öğretmen</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td class="style2">
                    <asp:TextBox ID="sorgulaTXT" runat="server" style="text-align:center;" BackColor="#3ed4dd"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
             </td>
            <td class="style3">
                <asp:Button ID="sorgulaBTN" runat="server" 
                 BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
                Height="30px" Text="Sorgula" Width="70px" onclick="dersSecBTN_Click" />
            </td>
            <td>
                <asp:Label ID="kontrolTXT" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="sqlSorgu" runat="server" Visible="False"></asp:Label>

                <asp:Button ID="silBTN" runat="server" 
                 BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
                Height="30px" Text="Seçili Kayıtları Sil" Width="130px" style="float:right;"
                    Visible="False" onclick="silBTN_Click" />

            </td>
        </tr>
    </table>
    <div class="SagBolum" style="width:900px;height:auto;">
        <center><asp:Label ID="karsilama" runat="server" Text="- Sorgulama Yapınız -" 
                ForeColor="White"></asp:Label></center>
        
        <asp:Panel ID="seciliyiGucelle" runat="server" Visible="False">
        <table style="width:100%; margin-top: 0px;">
            <tr>
                <td class="style16">
                  <asp:DropDownList ID="kursSecListele" runat="server" Width="146px" Height="30px">
                  </asp:DropDownList>
              </td>
              <td class="style14">
                  <asp:DropDownList ID="siniflar" runat="server" Width="146px" Height="30px">
                  </asp:DropDownList>
              </td>
              <td class="style7">
                  <asp:RadioButtonList ID="cinsiyetRADIO" runat="server" ForeColor="White" 
                      RepeatDirection="Horizontal" style="margin-left: 0px" Width="146px">
                      <asp:ListItem Selected="True" Value="1">Bayan</asp:ListItem>
                      <asp:ListItem Value="2">Erkek</asp:ListItem>
                  </asp:RadioButtonList>
                </td>
                <td colspan="3" align="right">
                    <asp:Label ID="secimID" runat="server" Visible="False"></asp:Label>
                    <asp:Button ID="guncelleBTN" runat="server" BorderColor="#000066" 
                        BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" Height="30px" 
                        style="text-align: center" Text="Güncelle" ValidationGroup="Guncelle" 
                        Width="140px" onclick="guncelleBTN_Click" />
                </td>
            </tr>
            <tr>
               <td colspan="6" align="right">
                   &nbsp;</td>
            </tr>
            <tr>
                
                <td style="color:#fff;" class="style17">Ad Soyad</td>
                <td style="color:#fff;" class="style15">TC</td>
                <td style="color:#fff;" class="style8">Telefon</td>
                <td style="color:#fff;" class="style6">E-Posta</td>
                <td style="color:#fff;" class="style18">Yaş</td>
                <td style="color:#fff;">Adres</td>
            </tr>
           <tr> 
              <td class="style16" valign="top"><asp:TextBox ID="adSoyad" runat="server" Height="25px" Width="140px"></asp:TextBox></td>
              <td class="style14" valign="top">
                  <asp:TextBox ID="tc" runat="server" Height="25px" Width="140px"></asp:TextBox>
               </td>
              <td class="style7" valign="top"><asp:TextBox ID="tel" runat="server" Height="25px" 
                      style="margin-left: 0px" Width="140px"></asp:TextBox></td>
              <td class="style5" valign="top"><asp:TextBox ID="ePosta" runat="server" Width="140px" 
                      Height="25px" style="margin-left: 0px"></asp:TextBox>
                  <br />
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                      ControlToValidate="ePosta" ErrorMessage="Geçerli e-Posta Yaz" ForeColor="White" 
                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                      ValidationGroup="Guncelle" Width="140px"></asp:RegularExpressionValidator>
               </td>
              <td class="style19" valign="top">
                  <asp:TextBox ID="yas" runat="server" Height="25px" Width="140px"></asp:TextBox>
               </td>
              <td valign="top">
                  <textarea ID="adres" runat="server" cols="20" name="S1" rows="2" 
                      style="width: 140px; height: 100px;"></textarea></td>
            </tr> 
         </table>   
        </asp:Panel>

        <asp:Panel ID="ogretmenGuncelle" runat="server" Visible="True">
        <table style="width:101%;">
            <tr>
                <td colspan="7" align="right">
                    <asp:Label ID="secim2ID" runat="server" Visible="False"></asp:Label>
                    <asp:Button ID="ogretmenGuncelleBTN" runat="server" BorderColor="#000066" 
                        BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" Height="30px" 
                        style="text-align: center" Text="Güncelle" ValidationGroup="Guncelle" 
                        Width="140px" onclick="ogretmenGuncelleBTN_Click" />
                </td>
            </tr>
            <tr>
               <td colspan="7" align="right" height="5"></td>
            </tr>
            <tr>
                <td style="color:#fff;" class="style22">Alanı</td>
                <td style="color:#fff;" class="style22">Ad Soyad</td>
                <td style="color:#fff;" class="style32">Yaş</td>
                <td style="color:#fff;" class="style24">SicilNo</td>
                <td style="color:#fff;" class="style26">Telefon</td>
                <td style="color:#fff;" class="style30">E-Posta</td>
                <td style="color:#fff;" class="style21">Adres</td>
            </tr>
           <tr> 
              <td class="style23" valign="top">
                  <asp:TextBox ID="alaniTXT" runat="server" 
                      Height="25px" Width="120px"></asp:TextBox></td>
              <td class="style23" valign="top">
                  <asp:TextBox ID="ogretmenAdiTXT" runat="server" 
                      Height="25px" Width="120px"></asp:TextBox></td>
              <td class="style33" valign="top">
                  <asp:TextBox ID="ogretmenYasTXT" runat="server" Height="25px" Width="85px"></asp:TextBox>
               </td>
              <td class="style25" valign="top">
                  <asp:TextBox ID="ogretmenSicilNoTXT" runat="server" Height="25px" Width="120px"></asp:TextBox>
               </td>
              <td class="style27" valign="top">
                  <asp:TextBox ID="ogretmenTelTXT" runat="server" Height="25px" 
                      style="margin-left: 0px" Width="120px"></asp:TextBox></td>
              <td class="style31" valign="top">
                  <asp:TextBox ID="ogretmenEPostaTXT" runat="server" Width="120px" 
                      Height="25px" style="margin-left: 0px"></asp:TextBox>
                  <br />
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                      ControlToValidate="ePosta" ErrorMessage="Geçerli e-Posta Yaz" ForeColor="White" 
                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                      ValidationGroup="Guncelle" Width="120px"></asp:RegularExpressionValidator>
               </td>
              <td valign="top">
                  <textarea ID="ogretmenAdresTXT" runat="server" cols="20" name="S1" rows="2" 
                      style="width: 140px; height: 100px;"></textarea></td>
            </tr> 
         </table>   
        </asp:Panel>
        
        <asp:GridView ID="GridView_ogrenci" DataKeyNames="id" 
            AutoGenerateColumns="False" CellPadding="5" runat="server" style="width:900px;height:auto;" 
            BackColor="White" 
            HorizontalAlign="Left" 
            onselectedindexchanged="GridView_ogrenci_SelectedIndexChanged">
        <Columns>
                <asp:TemplateField ItemStyle-Width="20">
                    <ItemTemplate>
                        <asp:CheckBox ID="ogrenciSecim" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="15px" />
                <asp:BoundField HeaderText="Ad Soyad" DataField="adSoyad" ItemStyle-Width="130px" />
                <asp:BoundField HeaderText="Yaş" DataField="yas" ItemStyle-Width="20px" />
                <asp:BoundField HeaderText="Tc" DataField="tc" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="Telefon" DataField="tel" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="e-Posta" DataField="ePosta" ItemStyle-Width="130px" />
                <asp:BoundField HeaderText="Adres" DataField="adres" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" ItemStyle-Width="30px" Text="Seç"/>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="GridView_ogretmen" DataKeyNames="id" 
            AutoGenerateColumns="False" CellPadding="5" runat="server" style="width:900px;height:auto;" 
            BackColor="White" 
            HorizontalAlign="Left" 
            onselectedindexchanged="GridView_ogretmen_SelectedIndexChanged" >
        <Columns>
                <asp:TemplateField ItemStyle-Width="20">
                    <ItemTemplate>
                        <asp:CheckBox ID="ogretmenSecim" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="15px" />
                <asp:BoundField HeaderText="Alanı" DataField="alan" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="Ad Soyad" DataField="adSoyad" ItemStyle-Width="130px" />
                <asp:BoundField HeaderText="Yaş" DataField="yas" ItemStyle-Width="20px" />  
                <asp:BoundField HeaderText="Sicil No" DataField="sicilNo" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="Telefon" DataField="tel" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="e-Posta" DataField="ePosta" ItemStyle-Width="130px" />
                <asp:BoundField HeaderText="Adres" DataField="adres" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" ItemStyle-Width="30px" Text="Seç"/>
            </Columns>
        </asp:GridView>
    </div>
    </asp:Content>
