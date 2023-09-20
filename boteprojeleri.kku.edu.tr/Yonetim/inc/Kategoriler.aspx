<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="Yonetim_inc_Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <table style="width:100%;" border="0">
                <tr>
                    <td><h3><i class="fa fa-angle-right"></i> Kategoriler</h3></td>
                    <td style="text-align:right;">
                        <asp:TextBox ID="kategoriTXT" class="form-control" placeholder="Yeni kategori başlığını yazınız. (240 Karakter)" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align:right; width:75px;">
                        <asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Oluştur" OnClick="kaydetBTN_Click" />
                    </td>
                </tr>
            </table>
          	<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          <table class="table table-striped table-advance table-hover">
                              <thead>
                              <tr>
                                  <th><i class="fa fa-bullhorn"></i> Kategori Başlığı</th>
                                  <th><i class=" fa fa-edit"></i> Durumu</th>
                                  <th></th>
                              </tr>
                              </thead>
                              <tbody>
                              <asp:Repeater ID="rptKategoriler" runat="server" OnItemCommand="rptKategoriler_ItemCommand">
                                <ItemTemplate>
                                  <tr>
                                      <td class="hidden-phone"><%#Eval("baslik") %></td>
                                      <td style="width:84px;">
                                          <asp:Button ID="kontrolBTN" CommandName="CheckBoxKontrol" CommandArgument='<%#Eval("id") %>' CssClass='<%#Eval("kontrol").ToString()=="1"?"AcikBTN":"KapaliBTN" %>' ValidationGroup="kontrol" runat="server" Text='<%#Eval("kontrol").ToString()=="1"?"Yayında":"Gizli" %>' />
                                      </td>
                                      <td style="text-align:right;width:25%; padding-left:0;">
                                          <asp:TextBox ID="baslikTXT" Text='<%#Eval("baslik") %>' class="form-control" placeholder="Kategori başlığı yazınız." ValidationGroup="guncelle" runat="server"></asp:TextBox>
                                      </td>
                                      <td style="width:50px; padding-left:0; padding-right:0;">
                                          <asp:Button ID="Button1" CommandName="GuncelleBTN" CommandArgument='<%#Eval("id") %>' class="GuncelleBTN" ValidationGroup="guncelle" runat="server" Text="&nbsp;" />
                                      </td>  
                                      <td style="width:50px; padding-left:0;">
                                          <asp:Button ID="Button2" CommandName="ProjeSilBTN" CommandArgument='<%#Eval("id") %>' class="SilBTN" runat="server" ValidationGroup="sil" Text="&nbsp;" />
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

