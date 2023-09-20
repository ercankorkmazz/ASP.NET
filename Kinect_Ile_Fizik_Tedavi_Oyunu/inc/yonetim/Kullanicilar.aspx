<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Kullanicilar.aspx.cs" Inherits="inc_yonetim_Kullanicilar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
	    
	</div>
	<div class="row" style="text-align:justify;"> 

    </div>

    <div class="row row-bottom-padded-md">
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

		<div class="col-md-6 to-animate">
		    <div class="col-md-12 section-heading text-center" style="height:80px; margin-bottom:10px;">
	            <h2 class="to-animate" style="font-size:30px;">FİZYOTERAPİST KAYITLARI</h2>
		    </div>
            <table width="100%" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtfizyoadi" placeholder="Adı Soyadı" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top:10px;">
                        <asp:TextBox ID="txtfizyokadi" placeholder="Kullanıcı Adı" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td style="padding-top:10px;">
                        <asp:TextBox ID="txtfizyosifre" placeholder="Şifre" CssClass="form-control" style="text-align:center; font-weight:bold;" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td style="padding-top:10px; text-align:center;">
                        <asp:Button ID="btnfizyoekle" CssClass="btn btn-primary" style="width:200px;" runat="server" Text="Ekle" OnClick="btnfizyoekle_Click"/>
                    </td>
                </tr>
            </table>
            <table class="table table-hover" style="margin-top:20px;">
					<thead>
						<tr>
						  <th style="width:100px;">#</th>
                          <th style="width:33%;">Adı Soyadı</th>
                          <th style="width:33%;">Kullanıcı Adı</th>
						  <th style="width:33%;">Şifre</th>
						  <th>&nbsp;</th>
						</tr>
					</thead>
					<tbody>
                        <asp:Repeater ID="RPTFizyoterapistler" runat="server" OnItemCommand="RPTFizyoterapistler_ItemCommand">
                            <ItemTemplate>
						        <tr>
						            <td style="padding-top:15px;"><%#Eval("id") %></td>
                                    <td style="padding-top:15px;"><%#Eval("adSoyad") %></td>
						            <td style="padding-top:15px;"><%#Eval("kadi") %></td> 
                                    <td style="padding-top:15px;"><%#Eval("sifre") %></td>
                                    <td><asp:Button ID="SilBtn" runat="server" CommandName="silButonlari" CommandArgument='<%#Eval("id") %>' class="btn btn-danger" Text="Sil"/></td>
						        </tr>
                            </ItemTemplate>
                        </asp:Repeater>
					</tbody>
                    
            </table>
		</div>

	</div>

</asp:Content>

