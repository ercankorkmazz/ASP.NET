<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Projeler.aspx.cs" Inherits="Yonetim_inc_Projeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <table style="width:100%;" border="0">
                <tr>
                    <td><h3><i class="fa fa-angle-right"></i> Projeler</h3></td>
                    <td style="text-align:right;">
                        <asp:TextBox ID="baslikTXT" ValidationGroup="projeEkle" class="form-control" placeholder="Yeni proje başlığını yazınız. (240 Karakter)" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="kategorilerDropDownList" runat="server"
                            Width="100%" ValidationGroup="projeEkle" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:right; width:75px;">
                        <asp:Button ID="kaydetBTN" ValidationGroup="projeEkle" class="btn btn-success" runat="server" Text="Oluştur" OnClick="kaydetBTN_Click" />
                    </td>
                </tr>
            </table>
          	<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          <table class="table table-striped table-advance table-hover">
                              <thead>
                              <tr>
                                  <td><i class="fa fa-bullhorn"></i> Proje Başlığı</td>
                                  <td><i class=" fa fa-edit"></i> Kategori</td>
                                  <td colspan="2"></td>
                              </tr>
                              </thead>
                              <tbody>
                              <asp:Repeater ID="rptProjeler" runat="server" OnItemCommand="rptKategoriler_ItemCommand">
                                <ItemTemplate>
                                  <tr>
                                      <td class="hidden-phone"><%#Eval("projeBasligi") %></td>
                                      <td style="text-align:left;">
                                          <%#Eval("baslik") %>
                                      </td>
                                      <td style="width:50px; padding-left:0; padding-right:0;">
                                          <asp:Button ID="Button1" CommandName="GuncelleBTN" CommandArgument='<%#Eval("id") %>' class="GuncelleBTN" runat="server" Text="&nbsp;" />
                                      </td>  
                                      <td style="width:50px; padding-left:0;">
                                          <asp:Button ID="Button2" CommandName="SilBTN" CommandArgument='<%#Eval("id") %>' class="SilBTN" runat="server" Text="&nbsp;" />
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

