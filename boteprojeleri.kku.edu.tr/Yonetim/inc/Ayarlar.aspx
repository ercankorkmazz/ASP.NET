<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Ayarlar.aspx.cs" Inherits="Yonetim_inc_Ayarlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <h3><i class="fa fa-angle-right"></i> Ayarlar / Kullanıcı Ayarları</h3>
          	<div class="row mt">
          	    <div class="col-lg-12">
                      <table border="0" style="width:100%;">
                          <tr>
                              <td colspan="2"><h4 style="padding-bottom:0;">Ad Soyad</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="adSoyadTXT" placeholder="Ad soyad yazınız." runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">
                                <asp:Button ID="adSoyadGuncelleBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="adSoyadGuncelleBTN_Click" />
                              </td>
                          </tr>
                          <tr>
                              <td colspan="2"><h4 style="padding-bottom:0;">Kullanıcı Adı</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="kadiTXT" placeholder="Kullanıcı adı yazınız." runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">
                                <asp:Button ID="kadiGuncelleBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="kadiGuncelleBTN_Click" />
                              </td>
                          </tr>
                          <tr>
                              <td colspan="2"><h4 style="padding-bottom:0;">E-Posta</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="postaTXT" placeholder="E-Posta yazınız." runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">
                                <asp:Button ID="iletisimGuncelleBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="iletisimGuncelleBTN_Click" />
                              </td>
                          </tr>
                          <tr>
                              <td colspan="2" style="padding-top:30px;">&nbsp;</td>
                          </tr>
                          <tr>
                              <td colspan="2"><h4 style="padding-bottom:0;">Şifre Güncelle</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="mevcut" placeholder="Mevcut Şifre" TextMode="Password" runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">
                                <asp:Button ID="sifreGuncelleBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="sifreGuncelleBTN_Click" />
                              </td>
                          </tr>
                          <tr>
                              <td style="padding-top:10px;">
                                <asp:TextBox ID="ySifre" placeholder="Yeni Şifre" TextMode="Password" runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">&nbsp;</td>
                          </tr>
                          <tr>
                              <td style="padding-top:10px;">
                                <asp:TextBox ID="tSifre" placeholder="Yeni Şifre Tekrarı" TextMode="Password" runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;">&nbsp;</td>
                          </tr>
                      </table>
          		</div>
          	</div>
		 </section>
    </section>
</asp:Content>

