<%@ Page Title="Öğretmen Sorgula" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ogretmenKayit.aspx.cs" Inherits="ogretmenKayit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            width: 351px;
        }
        .style4
        {
            width: 120px;
            height: 30px;
        }
        .style5
        {
            width: 183px;
            height: 30px;
        }
        .style6
        {
            height: 30px;
            text-align: left;
            color: #FF0000;
        }
        .style7
        {
            color: #FF0000;
        }
        .style8
        {
            width: 39%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <table border="0" width="100%">
    <tr>
        <td class="style8"><h2>Öğretmen Kaydı</h2></td>
        <td align="right" class="style3">
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
    <div class="SagBolum" style="width:900px;height:auto;float:none;">
        <center>
        <table style="width:72%;margin-left:140px;" border=0>
        
            <tr>
                <td colspan=2 style="text-align: right">
                    <h3 style="float: right;">Öğretmen Kaydı</h3>
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td style="width:120px;">
                    <h3>Alanı:</h3>
                </td>
                <td style="width:183px;">
                    <asp:TextBox ID="alanTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left"><span class="style7">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="alanTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <h3>Ad Soyad:</h3>
                </td>
                <td class="style5">
                    <asp:TextBox ID="adSoyadTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td class="style6">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="adSoyadTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:120px;">
                    <h3>Yaş:</h3>
                </td>
                <td style="width:183px;">
                    <asp:TextBox ID="yasTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="yasTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:120px;">
                    <h3>Sicil No:</h3>
                </td>
                <td  style="width:183px;">
                   <asp:TextBox ID="sicilNoTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="sicilNoTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:120px;">
                    <h3>Tel:</h3>
                </td>
                <td>
                    <asp:TextBox ID="telTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="telTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>E-Posta:</h3>
                </td>
                <td style="width:183px;">
                    <asp:TextBox ID="ePostaTXT" runat="server"
                       BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="26px" 
                        Width="185px"></asp:TextBox>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="ePostaTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="ePostaTXT" ErrorMessage="Geçerli bir adres yazınız." 
                        ForeColor="White" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="ogretmen"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>Adres:</h3>
                </td>
                <td style="width:183px;">
                    <textarea id="adresTXT" cols="20" rows="2" runat="server" style="width:183px;"></textarea>
                </td>
                <td style="text-align: left; color: #FF0000">*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="adresTXT" CssClass="style7" 
                        ErrorMessage="Bu alan boş bırakılamaz." ForeColor="White" 
                        ValidationGroup="ogretmen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td colspan=2 style="text-align: right">
                    <asp:Button ID="ogretmenKaydetBTN" runat="server" 
            BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
            Height="30px" Text="Kaydet" Width="60px" 
                        style="text-align: right" onclick="ogretmenKaydetBTN_Click" 
                        ValidationGroup="ogretmen" />
                    <br />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
