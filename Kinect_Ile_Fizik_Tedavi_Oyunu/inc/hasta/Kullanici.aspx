<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Kullanici.aspx.cs" Inherits="inc_hasta_Kullanici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
	    
	</div>
	<div class="row" style="text-align:justify;"> 

    </div>

    <div class="row row-bottom-padded-md">

		<div class="col-md-3 to-animate">&nbsp;</div>

	    <div class="col-md-6 to-animate">
			<div class="col-md-12 section-heading text-center" style="height:80px; margin-bottom:10px;">
	            <h2 class="to-animate" style="font-size:30px;">KULLANICI BİLGİLERİ</h2>
		    </div>
            <table width="100%" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="uyeAdSoyadTXT" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top:10px;">
                        <asp:TextBox ID="uyeKadiTXT" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td style="padding-top:10px;">
                        <asp:TextBox ID="uyeSifreTXT" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td style="padding-top:10px; text-align:center;">
                        <asp:Button ID="GuncelleBtn" CssClass="btn btn-success" style="width:200px;" runat="server" Text="GÜncelle" OnClick="GuncelleBtn_Click" />
                    </td>
                </tr>
            </table>

		</div>

		<div class="col-md-3 to-animate">&nbsp;</div>

	</div>

</asp:Content>

