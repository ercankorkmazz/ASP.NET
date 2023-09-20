<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Proje.aspx.cs" Inherits="Yonetim_inc_Proje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <table style="width:100%;" border="0">
                <tr>
                    <td>
                        <h3><i class="fa fa-angle-right"></i> Proje / <span style="font-size:15px;">
                            <asp:Label ID="projeBasligiLABEL" runat="server" Text="-"></asp:Label></span>
                        </h3>
                    </td>
                    <td style="text-align:right; width:75px;">
                        <asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="kaydetBTN_Click" />
                    </td>
                </tr>
            </table>
            <div class="row mt">
					<div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 desc">
						<div class="project-wrapper">
		                    <div class="project">
		                        <div class="photo-wrapper">
		                            <div class="photo">
		                            	
		                            </div>
		                            <div class="overlay"></div>
		                        </div>
		                    </div>
		                </div>
					</div><!-- col-lg-4 -->
                </div>
          	<div class="row mt">
          	    <div class="col-lg-12">
                      <table border="0" style="width:100%;">
                          <tr>
                              <td style="width:50%;"><h4 style="padding-bottom:0;">Proje Başlığı</h4></td>
                              <td style="padding-left:11px;" colspan="2"><h4 style="padding-bottom:0;">Kategori</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="projeBasligiTXT" placeholder="Proje başlığını yazınız." runat="server" CssClass="form-control" Font-Bold="True" ValidationGroup="adSoyad"></asp:TextBox>
                              </td>
                              <td style="padding-left:10px;" colspan="2">
                                <asp:DropDownList ID="kategorilerDropDownList" runat="server"
                                    Width="100%" ValidationGroup="projeEkle" CssClass="form-control">
                                </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Proje Hakkında Kısa Açıklama</h4>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                <textarea id="kisaAciklamaTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Resim Yükleyiniz</h4>
                              </td>
                          </tr>
                          <tr>
                              <td>
                                <asp:FileUpload ID="fluDosya" runat="server" Width="100%" CssClass="form-control-file" />
                              </td>
                              <td colspan="2">
                                  <asp:Label ID="resimBilgiLABEL" runat="server" Font-Bold="true" Text=" Resim yükleyiniz. (Önerilen genişlik: 350px)"></asp:Label>
                                  <table border="0" style="width:100%;">
                                        <tr>
                                            <td style="width:30px;"><asp:Button ID="resimSilBTN" CssClass="SilBTN" runat="server" OnClick="resimSilBTN_Click" /></td>
                                            <td>
                                                <a id="resimGoruntuleBTN" href="~/img/portfolio/port04.jpg" Class="onIzemeBTN fancybox" runat="server"></a>
                                            </td>
                                        </tr>
                                  </table>
                                  
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3"><h4 style="padding-bottom:0;">URL Adresi</h4></td>
                          </tr>
                          <tr>
                              <td>
                                <asp:TextBox ID="urlTXT" placeholder="URL adresini yazınız. ÖRN: http: //geleceginprogramcilari.com" runat="server" CssClass="form-control" Font-Bold="True"></asp:TextBox>
                              </td>
                              <td style="width:30px;">
                                  <asp:Button ID="kontrolBTN" OnClick="kontrolBTN_Click" runat="server" />
                              </td>
                              <td>
                                  <span><strong>Dikkat:</strong> URL Aktif edildiğinde aşağıdaki bilgiler yayınlanmayacaktır.</span>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Proje Hakkında</h4>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                <textarea id="projeHakkindaTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Proje Ekibi</h4>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                <textarea id="projeEkibiTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Yayınlar</h4>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                <textarea id="yayinlarTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                  <h4 style="padding-bottom:0;">Duyurular</h4>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3">
                                <textarea id="duyurularTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                              </td>
                          </tr>
                      </table>
          		</div>
          	</div>
		 </section>
    </section>
</asp:Content>

