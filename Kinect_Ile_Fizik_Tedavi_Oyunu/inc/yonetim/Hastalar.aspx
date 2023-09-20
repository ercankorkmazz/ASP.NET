<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Hastalar.aspx.cs" Inherits="inc_yonetim_Hastalar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
	    <div class="col-md-12 section-heading text-center" style="height:80px;">
	        <h2 class="to-animate">HASTA KAYITLARI</h2>
		</div>
	</div>
	<div class="row" style="text-align:justify;"> 
          <table width="100%" border="0" style="margin-bottom:20px; background:#45A9D5; padding:10px;">
              <tr>
                <td width="20%" style="padding:10px 0 10px 10px;">
                    <asp:TextBox ID="tcNO" placeholder="TC Kimlik No" class="form-control" runat="server" MaxLength="11"></asp:TextBox>
                </td>
                <td width="20%" style="padding:10px;">
                  <asp:TextBox ID="adSoyad"  class="form-control" placeholder="Ad Soyad" runat="server"></asp:TextBox>
                </td>
                <td style="width:110px;">
                    <asp:Button ID="BtnListele" runat="server" class="btn btn-default" Text="LİSTELE" OnClick="BtnListele_Click" />
                </td>
                <td style="padding-left:10px; padding-right:10px; text-align:right;">
                    <asp:Button ID="BtnYeniKayit" runat="server" class="btn btn-default" Text="YENİ KAYIT" OnClick="BtnYeniKayit_Click" />
                </td>
              </tr>
        </table>

        <div class="bs-docs-example">
				<table class="table table-hover">
					<thead>
						<tr>
						  <th style="width:100px;">#</th>
                          <th style="width:150px;">TC Kimlik No</th>
						  <th>Ad Soyad</th>
						  <th style="width:130px;">&nbsp;</th>
						  <th style="width:130px;">&nbsp;</th>
						  <th style="width:80px;">&nbsp;</th>
						</tr>
					</thead>
					<tbody> 
                        <asp:Repeater ID="RPTHastalar" runat="server" OnItemCommand="RPTHastalar_ItemCommand">
                            <ItemTemplate>
						        <tr>
						            <td>
                                        <asp:LinkButton ID="LinkButton1" CssClass="linkButton" runat="server" PostBackUrl='<%#Eval("id","~/inc/yonetim/Seviyeler.aspx?hasta={0}") %>'><%#Eval("id") %></asp:LinkButton> 
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton2" CssClass="linkButton" runat="server" PostBackUrl='<%#Eval("id","~/inc/yonetim/Seviyeler.aspx?hasta={0}") %>'><%#Eval("TC") %></asp:LinkButton> 
                                    </td>
						            <td>
                                        <asp:LinkButton ID="LinkButton3" CssClass="linkButton" runat="server" PostBackUrl='<%#Eval("id","~/inc/yonetim/Seviyeler.aspx?hasta={0}") %>'><%#Eval("adSoyad") %></asp:LinkButton> 
                                    </td>
                                    <td><asp:Button ID="hastaTakipBTN" runat="server" CommandName="takipButonlari" CommandArgument='<%#Eval("id") %>' class="btn btn-warning" Text="Hasta Takibi"/></td>
                                    <td><asp:Button ID="DuzenleBtn" runat="server" CommandName="duzenleButonlari" CommandArgument='<%#Eval("id") %>' class="btn btn-primary" Text="Düzenle"/></td>
						            <td><asp:Button ID="SilBtn" runat="server" CommandName="silButonlari" CommandArgument='<%#Eval("id") %>' class="btn btn-danger" Text="Sil"/></td>
                                    </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5" style="text-align:center;"><asp:Label ID="bilgiTXT" runat="server" Text="Kayıt sorgulayınız."></asp:Label></td>
                        </tr>
					</tbody>
                    
            </table>
</div>  
    </div>
</asp:Content>

