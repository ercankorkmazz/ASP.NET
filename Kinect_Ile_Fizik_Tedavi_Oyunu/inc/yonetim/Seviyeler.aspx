<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Seviyeler.aspx.cs" Inherits="_Seviyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
	    <div class="col-md-12 section-heading text-center" style="height:80px;">
	        <h2 class="to-animate">
                <asp:label id="hastaAdiTXT" runat="server" text="HASTA TAKİBİ"></asp:label>
	        </h2>
		</div>
	</div>
	<div class="row" style="text-align:justify;"> 
        <table width="100%" border="0" style="margin-bottom:20px; background:#45A9D5; padding:10px;">
              <tr>
                <td width="20%" style="padding:10px;">
                    <asp:DropDownList ID="SeviyelerDROP" class="form-control" runat="server">
                        <asp:ListItem Value="0">Seviye Belirleyiniz</asp:ListItem>
                        <asp:ListItem Value="1">1 Seviye</asp:ListItem>
                        <asp:ListItem Value="2">2 Seviye</asp:ListItem>
                        <asp:ListItem Value="3">3 Seviye</asp:ListItem>
                        <asp:ListItem Value="4">4 Seviye</asp:ListItem>
                        <asp:ListItem Value="5">5 Seviye</asp:ListItem>
                        <asp:ListItem Value="6">6 Seviye</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:110px;">
                    <asp:Button ID="BtnListele" runat="server" class="btn btn-default" Text="BELİRLE" OnClick="BtnListele_Click" />
                </td>
                <td style="padding-left:10px; padding-right:10px; text-align:right;">
                    <asp:button id="geriDonBTN" runat="server" class="geriDonBeyazBTN" style="width:150px;" text="Geri Dön" OnClick="geriDonBTN_Click" />
                </td>
              </tr>
        </table>
        <table width="100%" border="0" class="table table-hover">
            <tbody> 
                <asp:Repeater ID="RPTSeviyeler" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CssClass="linkButton" runat="server" PostBackUrl='<%# String.Format("~/inc/yonetim/Seviye.aspx?hasta={0}&seviye={1}", DataBinder.Eval(Container.DataItem, "hastaID"), DataBinder.Eval(Container.DataItem, "seviye")) %>'><%#Eval("seviye") %>. Seviye</asp:LinkButton> 
                        </td>
                        <td style="text-align:right;">
                            <asp:LinkButton ID="LinkButton2" CssClass="linkButton" runat="server" PostBackUrl='<%# String.Format("~/inc/yonetim/Seviye.aspx?hasta={0}&seviye={1}", DataBinder.Eval(Container.DataItem, "hastaID"), DataBinder.Eval(Container.DataItem, "seviye")) %>'>
                                <img src="../../images/go.png" />
                            </asp:LinkButton> 
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </div>
</asp:Content>

