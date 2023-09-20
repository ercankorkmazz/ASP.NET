<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HastaTakibi.aspx.cs" Inherits="inc_yonetim_HastaTakibi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:button id="geriDonBTN" runat="server" class="geriDonBTN" style="width:200px;" text="Geri Dön" OnClick="geriDonBTN_Click" />
    <div class="row">
	    <div class="col-md-12 section-heading text-center" style="height:80px;">
	        <h2 class="to-animate">
                <asp:label id="hastaAdiTXT" runat="server" text="HASTA TAKİBİ"></asp:label>
            </h2>
		</div>
	</div>
	<div class="row" style="text-align:justify;"> 
        <table class="table table-hover">
					<thead>
						<tr>
						  <th style="width:100px;">#</th>
						  <th style="width:140px;">Tarih</th>
                          <th style="width:120px;">Aşama</th>
						  <th>Başarı Durumu</th>
						</tr>
					</thead>
					<tbody>
                        <asp:Repeater ID="RPTHastaTakibi" runat="server">
                            <ItemTemplate>
						        <tr>
						            <td style="padding-top:15px;"><%#Eval("id") %></td>
                                    <td style="padding-top:15px;"><%#Eval("tarih") %></td>
                                    <td style="padding-top:15px;"><%#Eval("asamaNO") %></td>
						            <td style="padding-top:15px;"><%#Eval("basari") %></td> 
						        </tr>
                            </ItemTemplate>
                        </asp:Repeater>
					</tbody>
                    
            </table>
    </div>
</asp:Content>

