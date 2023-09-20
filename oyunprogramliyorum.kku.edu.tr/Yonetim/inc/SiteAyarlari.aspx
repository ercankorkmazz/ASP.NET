<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="SiteAyarlari.aspx.cs" Inherits="Yonetim_inc_SiteAyarlari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <h3><i class="fa fa-angle-right"></i> Ayarlar / Site Ayarları</h3>
            <hr />
          	<div class="row mt">
          	    <div class="col-lg-12">
          		    <table border="0" style="width:100%;">
                          <tr>
                              <td colspan="2" style="text-align:right; height:50px;"><asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="kaydetBTN_Click" /></td>
                          </tr>
                          <tr>
                              <td style="text-align:right;"><strong>Title: </strong></td>
                              <td>
                                  <asp:TextBox ID="titleTXT" class="form-control" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:80px; height:50px; text-align:right;"><strong>Banner Text: </strong></td>
                              <td>
                                  <asp:TextBox ID="bannerTextTXT" class="form-control" runat="server"></asp:TextBox>
                              </td>
                          </tr>
          		    </table>
          		</div>
          	</div>
		 </section>
    </section>
</asp:Content>

