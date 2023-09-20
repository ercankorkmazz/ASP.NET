<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Seviye.aspx.cs" Inherits="_Seviye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:button id="geriDonBTN" runat="server" class="geriDonBTN" style="width:200px;" text="Geri Dön" OnClick="geriDonBTN_Click" />
    <div class="row">
	    <div class="col-md-12 section-heading text-center" style="height:80px;">
	        <h2 class="to-animate"><asp:label id="SeviyeNoTXT" runat="server" text="HASTA TAKİBİ"></asp:label></h2>
		</div>
	</div>
	<div class="row padding5" style="text-align:justify;"> 
          <table width="100%" border="0" style="margin-bottom:20px; background:#45A9D5; padding:10px;">
              <tr>
                <td style="padding:10px 0 10px 10px;">
                    <asp:DropDownList ID="hareketlerDROP" class="form-control" runat="server"></asp:DropDownList>
                </td>
                <td width="22%" style="padding:10px; padding-right:0;">
                  <asp:TextBox ID="tekrarTXT" class="form-control" placeholder="Tekrar sayısını giriniz." runat="server"></asp:TextBox>
                </td>
                <td width="22%" style="padding:10px;">
                    <asp:TextBox ID="beklemeTXT" placeholder="Bekleme süresi (saniye)" class="form-control" runat="server"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td colspan="2" style="padding:0 0 10px 10px;">
                    <asp:TextBox ID="aciklamaTXT" placeholder="Harekete ilişkin açıklama yazınız." class="form-control" runat="server"></asp:TextBox>
                </td>
                <td style="padding:10px; padding-top:0;">
                    <asp:Button ID="HareketEkleBTN" runat="server" class="btn btn-default" Width="100%" Text="Kaydet" OnClick="HareketEkleBTN_Click" />
                </td>

              </tr>    
        </table>

        <div class="bs-docs-example">
				<table class="table table-hover">
					<thead>
						<tr>
						  <th style="width:100px;">#</th>
                          <th>Hareket Tanımı</th>
						  <th style="width:150px;">Tekrar Sayısı</th>
						  <th style="width:170px;">Bekleme Süresi</th>
						  <th style="width:25%;">Açıklama</th>
                          <th style="width:80px;">&nbsp;</th>
						</tr>
					</thead>
					<tbody> 
                        <asp:Repeater ID="RPTEgzersizProgrami" runat="server" OnItemCommand="RPTEgzersizProgrami_ItemCommand">
                            <ItemTemplate>
						        <tr>
						            <td><%#Eval("id") %></td>
                                    <td><%#Eval("hareketTanimi") %></td>
                                    <td><%#Eval("hareketTekrari") %></td>
						            <td><%#Eval("beklemeSuresi") %> Saniye</td>
                                    <td><%#Eval("aciklamalar") %></td>
						            <td><asp:Button ID="SilBtn" runat="server" CommandName="silButonlari" CommandArgument='<%#Eval("id") %>' class="btn btn-danger" Text="Sil"/></td>
                                    </tr>
                            </ItemTemplate>
                        </asp:Repeater>
					</tbody>
                    
            </table>
</div>  
    </div>
</asp:Content>

