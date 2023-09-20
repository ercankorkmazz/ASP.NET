<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="SiteAyarlari.aspx.cs" Inherits="Yonetim_inc_SiteAyarlari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <h3><i class="fa fa-angle-right"></i> Ayarlar / Site Ayarları</h3>
          	<div class="row mt">
          	    <div class="col-lg-12">
          		    <table border="0" style="width:100%;">
                          <tr>
                              <td colspan="2" style="text-align:right; height:50px;"><asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="kaydetBTN_Click" /></td>
                          </tr>
                          <tr>
                              <td style="text-align:right;"><strong>Başlık: </strong></td>
                              <td>
                                  <asp:TextBox ID="titleTXT" class="form-control" placeholder="Site başlığı yazınız. (200 Karakter)" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Anahtar Kelimeler: </strong></td>
                              <td>
                                  <asp:TextBox ID="anahtarKelimelerTXT" class="form-control" placeholder="Anahtar kelimleri yazınız. Örnek: TÜBİTAK, Proje, Kırıkkale, KKU" runat="server"></asp:TextBox>
                              </t>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;vertical-align:top; padding-top:8px;"><strong>Site Açıklaması: </strong></td>
                              <td style="padding-bottom:10px;">
                                  <asp:TextBox ID="aciklamaTXT" class="form-control" placeholder="Site hakkında açıklama yapınız." runat="server" Font-Strikeout="False" TextMode="MultiLine"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right; vertical-align:top; padding-top:8px;"><strong>Biz kimiz?: </strong></td>
                              <td>
                                  <textarea id="hakkimizdaTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Adres: </strong></td>
                              <td>
                                  <asp:TextBox ID="adresTXT" class="form-control" placeholder="Adres yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Telefon: </strong></td>
                              <td>
                                  <asp:TextBox ID="telefonTXT" class="form-control" placeholder="Telefon numarası yazınız. (50 Karakter)" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>E-Posta: </strong></td>
                              <td>
                                  <asp:TextBox ID="ePostaTXT" class="form-control" placeholder="E-Posta adresi yazınız. (80 Karakter)" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Facebook: </strong></td>
                              <td>
                                  <asp:TextBox ID="facebookTXT" class="form-control" placeholder="Facebook bağlantısı yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Twitter: </strong></td>
                              <td>
                                  <asp:TextBox ID="twitterTXT" class="form-control" placeholder="Twitter bağlantısı yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Flickr: </strong></td>
                              <td>
                                  <asp:TextBox ID="flickrTXT" class="form-control" placeholder="Flickr bağlantısı yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Google+: </strong></td>
                              <td>
                                  <asp:TextBox ID="googleTXT" class="form-control" placeholder="Google+ bağlantısı yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:15%; height:50px; text-align:right;"><strong>Dribbble: </strong></td>
                              <td>
                                  <asp:TextBox ID="dribbbleTXT" class="form-control" placeholder="Dribbble bağlantısı yazınız." runat="server"></asp:TextBox>
                              </td>
                          </tr>
          		    </table>
          		</div>
          	</div>
		 </section>
    </section>
</asp:Content>

