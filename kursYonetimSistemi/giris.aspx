<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="giris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin:0;padding:0; background:#87CAD0;">
    <form id="form1" runat="server">
        <div style="width:350px; height:205px; margin:150px auto auto auto; background:url(img/girisBG.png);padding-top:100px;padding-bottom:20px;">
            <table style="width:300px;margin-left:15px;margin-top:15px; border:0;">
                <tr>
                    <td style="width:40px;" align="right"><img src="img/kAdi.png" /></td>
                    <td style="padding-left:15px;">
                        <asp:TextBox ID="kadiTXT" runat="server" Width="100%" Height="32px" 
                            
                            style="text-align:center;font-weight:bold;background:#87CAD0;border:1px solid #25738F;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right"><img src="img/sifre.png" /></td>
                    <td style="padding-left:15px;">
                        <asp:TextBox ID="sifreTXT" runat="server" Width="100%" Height="32px" 
                            
                            
                            style="text-align:center;font-weight:bold;background:#87CAD0;border:1px solid #25738F;" 
                            TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:Button ID="uyelikKontroluBTN" runat="server" 
            BorderColor="#25738F" BorderStyle="Solid" BorderWidth="1px" ForeColor="#000000" 
            Height="34px" Text="Giriş Yap" Width="90px" BackColor="#87CAD0" 
                            style="margin-right:-4px;" onclick="uyelikKontroluBTN_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right" height="50px">
                        <asp:Label ID="bilgiTXT" runat="server" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
