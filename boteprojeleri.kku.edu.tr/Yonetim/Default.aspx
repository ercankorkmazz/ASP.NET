<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Yonetim_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <h3><i class="fa fa-angle-right"></i> Anasayfa</h3>
          	<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          <table class="table table-striped table-advance table-hover">
                              <thead>
                              <tr>
                                  <td><i class="fa fa-edit"></i> AD SOYAD</td>
                                  <td><i class="fa fa-edit"></i> E-POSTA</td>
                                  <td><i class="fa fa-bullhorn"></i> KONU</td>
                                  <td><i class="fa fa-bullhorn"></i> MESAJ</td>
                                  <td></td>
                              </tr>
                              </thead>
                              <tbody>
                              <asp:Repeater ID="rptMesajlar" runat="server" OnItemCommand="rptMesajlar_ItemCommand">
                                <ItemTemplate>
                                  <tr>
                                      <td style="text-align:left;"><%#Eval("adSoyad") %></td>
                                      <td style="text-align:left;"><%#Eval("ePosta") %></td>
                                      <td style="text-align:left;"><%#Eval("konu") %></td>
                                      <td style="text-align:left;"><%#Eval("mesaj") %></td>
                                      <td style="width:50px; padding-left:0;">
                                          <asp:Button ID="Button2" CommandName="MesajSilBTN" CommandArgument='<%#Eval("id") %>' class="SilBTN" runat="server" Text="&nbsp;" />
                                      </td>
                                  </tr>
                                </ItemTemplate>
                              </asp:Repeater>
                              </tbody>
                          </table>
                      </div><!-- /content-panel -->
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->
		 </section>
    </section>
</asp:Content>

