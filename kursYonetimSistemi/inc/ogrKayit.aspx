<%@ Page Title="Öğrenci Kaydı" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ogrKayit.aspx.cs" Inherits="ogrKayit" %>

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
            width: 521px;
        }
        .style6
        {
            width: 165px;
        }
        .style7
        {
            width: 110px;
            color: #FF0000;
            text-align: left;
        }
        .style9
        {
            width: 7%;
        }
        .style10
        {
            width: 11%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td style="width:50%;"><h2>Öğrenci Kaydı</h2></td>
        <td align="right" class="style5">
            &nbsp;<asp:Label ID="bilgiTXT" 
                runat="server" Font-Bold="True" 
            ForeColor="Black" style="text-align: left" CssClass="bilgi" Font-Size="14px"></asp:Label>
        </td>
        <td align="left" style="width:25px;">
            <asp:Panel ID="bilgiIMG" runat="server" style="margin-left: 0px">
                <img src="../img/bilgi.png"/>
            </asp:Panel>
        </td>
    </tr>
   </table>
    <table style="width:100%;margin:10px 0 0 -3px;">
        <tr>
            <td class="style2">
              <asp:DropDownList ID="kursSecListele" runat="server" BackColor="#3ed4dd"
                 BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                 Width="190px">
               </asp:DropDownList>
             </td>
            <td class="style3">
                <asp:Button ID="dersSecBTN" runat="server" 
                 BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
                Height="30px" Text="Seç" Width="40px" onclick="dersSecBTN_Click" />
            </td>
            <td class="style6" style="width:200px;">
                <strong>Seçili Kurs:
                <asp:Label ID="kusAdiTXT" runat="server" Text="-" ForeColor="#3ED4DD"></asp:Label>
            </strong>
            </td>
            <td style="width:120px;">
                <strong>Kontenjan:
                <asp:Label ID="kontenjanTXT" runat="server" Text="-" ForeColor="#3ED4DD"></asp:Label>
            </strong>
            </td>
            <td style="width:150px;">
                <strong>Kurs Ücreti:
                <asp:Label ID="fiyatTXT" runat="server" Text="-" ForeColor="#3ED4DD"></asp:Label>
            </strong>
            </td>
            <td>
                <strong>Kurs Süresi: <asp:Label ID="kursSuresi" runat="server" Text="-" 
                    ForeColor="#3ED4DD"></asp:Label>
                </strong></td>
        </tr>
    </table>
    <div class="SagBolum" style="width:900px;height:auto;">
    <center>
        <table style="width:77%;margin-left:150px;" border=0>
        
            <tr>
                <td colspan=2 style="text-align: right"><asp:Label ID="kusID" runat="server" Text="Label" Visible="False"></asp:Label>
                    <h3 style="float:right;">Öğrenci Kaydı</h3>
                </td>
                <td class="style7">&nbsp; </td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Ad Soyad:</h3>
                </td>
                <td class="style9">
                    <asp:TextBox ID="adSoyadTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left" class="style7"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="adSoyadTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogrKayit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Yaş:</h3>
                </td>
                <td class="style9">
                    <asp:TextBox ID="yasTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left" class="style7"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="yasTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogrKayit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                   <h3>Cinsiyet:</h3>
                </td>
                <td class="style9">
                    <asp:RadioButtonList ID="cinsiyetRADIO" runat="server" ForeColor="White" 
                        RepeatDirection="Horizontal" style="margin-left: 0px" Width="181px">
                        <asp:ListItem Selected="True" Value="1">Bayan</asp:ListItem>
                        <asp:ListItem Value="2">Erkek</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style7"></td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Tc:</h3>
                </td>
                <td class="style9">
                   <asp:TextBox ID="tcTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left" class="style7"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tcTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogrKayit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Sınıflar:</h3>
                </td>
                <td class="style9">
                    <asp:DropDownList ID="sinif" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        Width="189px">
                    </asp:DropDownList>
                </td>
                <td class="style7">*</td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Tel:</h3>
                </td>
                <td class="style9">
                    <asp:TextBox ID="telTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left" class="style7"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="telTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogrKayit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>E-Posta:</h3>
                </td>
                <td class="style9">
                    <asp:TextBox ID="ePostaTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td><td 
                    class="style7">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="ePostaTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogrKayit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="ePostaTXT" ErrorMessage="Geçerli bir adres yazınız." 
                        ForeColor="White" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="ogrKayit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <h3>Adres:</h3>
                </td>
                <td class="style9">
                    <textarea id="adresTXT" cols="20" rows="2" runat="server" style="width:183px;"></textarea>
                </td>
                <td class="style7"></td>
            </tr>
            
            <tr>
                <td colspan=2 style="text-align: right">
                    <asp:Button ID="ornKaydetBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Kaydet" Width="60px" 
                        style="text-align: right" onclick="ornKaydetBTN_Click" 
                        ValidationGroup="ogrKayit" />
                </td>
                <td class="style7"></td>
            </tr>
        </table>
    </center>
    </div>
</asp:Content>
