<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HastaDuzenle.aspx.cs" Inherits="inc_yonetim_HastaDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:button id="geriDonBTN" runat="server" class="geriDonBTN" style="width:200px;" text="Geri Dön" OnClick="geriDonBTN_Click" />
    <div class="row">
	    <div class="col-md-12 section-heading text-center" style="height:80px;">
	        <h2 class="to-animate">HASTA KAYDI DÜZENLE</h2>
		</div>
	</div>
    <table class="table table-hover">
					<thead>
						<tr>
                          <th style="width:200px; text-align:center;">TC Kimlik Numarası</th>
						  <th style="width:230px; text-align:center;">Adı Soyadı</th>
						  <th style="width:130px; text-align:center;">Yaşı</th>
						  <th style="height: 23px; text-align:center;">Hastanın Durumu</th>
						</tr>
					</thead>
					<tbody>
				        <tr>
					        <td>
                                <asp:textbox id="tcNoTXT" class="form-control" style="text-align:center;" runat="server" MaxLength="11"></asp:textbox>
                            </td>
                            <td>
                                <asp:textbox id="adSoyadTXT" class="form-control" style="text-align:center;" runat="server"></asp:textbox>
                            </td>
						    <td>
                                <asp:textbox id="yasTXT" class="form-control" style="text-align:center;" runat="server"></asp:textbox>
						    </td>  
                            <td>
                                <asp:textbox id="hastaDurumuTXT" class="form-control" runat="server" TextMode="MultiLine"></asp:textbox>
                            </td>
				        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:button id="guncelleBTN" runat="server" class="btn btn-primary" style="width:200px;" text="Kaydet" OnClick="guncelleBTN_Click" />
                            </td>

                        </tr>
					</tbody>
                    
            </table>
     
	


</asp:Content>

