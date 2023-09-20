<%@ Page Title="Ders Programı" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="dersProgrami.aspx.cs" Inherits="dersProgrami" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            height: 31px;
        }
        .style3
        {
            color: #FFFFFF;
        }
        .style4
        {
            color: #FFFFFF;
            text-align: right;
            width: 75px;
        }
        .style5
        {
            width: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" width="100%">
    <tr>
        <td><h2>Ders Programı</h2></td>
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
    <table style="width:auto;margin:10px 0 0 -3px;">
        <tr>
            <td class="style2">
                    <asp:DropDownList ID="kursSecListele" runat="server"
            BorderColor="#000066" BorderStyle="Inset" BorderWidth="1px" Height="30px" 
                        BackColor="#3ed4dd">
                    </asp:DropDownList>
            </td>
            <td class="style3" style="height: 31px">
                <asp:Button ID="dersSecBTN" runat="server" 
                 BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
                Height="30px" Text="Listele" Width="70px" onclick="dersSecBTN_Click" />
            </td>
            <td>
                <asp:Label ID="secimID" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
    <div class="SagBolum" style="width:900px;height:auto;">
        <asp:GridView ID="GridView_dersProgram" DataKeyNames="id" 
            AutoGenerateColumns="False" CellPadding="5" runat="server" style="width:690px;height:auto;" 
            BackColor="White" 
            onselectedindexchanged="GridView_dersProgram_SelectedIndexChanged" 
            HorizontalAlign="Left">
        <Columns>
                <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="20px" />
                <asp:BoundField HeaderText="Saat" DataField="saat" ItemStyle-Width="36px" />
                <asp:BoundField HeaderText="Pazartesi" DataField="g1" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Salı" DataField="g2" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Çarşamba" DataField="g3" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Perşembe" DataField="g4" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Cuma" DataField="g5" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Cumartesi" DataField="g6" ItemStyle-Width="71px" />
                <asp:BoundField HeaderText="Pazar" DataField="g7" ItemStyle-Width="71px" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" ItemStyle-Width="48px" Text="Seç"/>
            </Columns>
        </asp:GridView>
        <asp:Panel ID="guncelle" runat="server" Visible="False">
            <table style="width:200px; float:left; margin-left: 10px;">
            <tr>
                 <td class="style4">Pazartesi: </td>
                 <td>
                     <asp:TextBox ID="pazartesiTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td class="style4">Salı: </td>
                 <td><asp:TextBox ID="saliTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox></td>
            </tr>
            <tr>
                 <td class="style4">Çarşamba: </td>
                 <td>
                     <asp:TextBox ID="carsambaTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td class="style4">Perşembe: </td>
                 <td>
                     <asp:TextBox ID="persembeTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td class="style4">Cuma: </td>
                 <td>
                     <asp:TextBox ID="cumaTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td class="style4">Cumartesi</td>
                 <td>
                     <asp:TextBox ID="cumartesiTXT" runat="server" Width="100%" CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                 <td class="style4">Pazar: </td>
                 <td>
                     <asp:TextBox ID="pazarTXT" runat="server" Width="100%" style="height: 22px" 
                         CssClass="input"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <asp:TextBox ID="seciliID" runat="server" Text="" Visible="false"></asp:TextBox>
                 <td colspan="2" class="style5" align="right">
                 <asp:Button ID="GuncelleBTN" runat="server" 
                BorderColor="#000066" BorderStyle="Solid" BorderWidth="1px" ForeColor="#465c71" 
                Height="30px" Text="Güncelle" Width="73px" 
                            style="margin-right:-6px;" onclick="GuncelleBTN_Click" />
                    
                 </td>
            </tr>
            </table>
        </asp:Panel>
        <center>
            <asp:Label ID="kursSeciniz" runat="server" Text=" - Kurs Seçiniz - " 
                ForeColor="White"></asp:Label>
        </center>
    </div>
</asp:Content>
