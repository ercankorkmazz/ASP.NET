<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Slider.aspx.cs" Inherits="Yonetim_inc_Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <h3><i class="fa fa-angle-right"></i> Slider</h3>
          	<div class="row mt">
          	    <div class="col-lg-12">
                    <table style="width:100%;" border="0">
                        <tr>
                            <td colspan="2" style="font-size:16px;"><strong>Başlık yazınız. (*)</strong> <span style="font-size:12px;">Not: Alt satıra geçmek için kaynak görünümünde &#8249;br /&#8250; tagını ekleyiniz.</span></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <textarea id="baslikTXT" style="font-weight:bold;" class="ckeditor" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-size:16px;"><strong>Açıklama yazınız.</strong> <span style="font-size:12px;">Not: Alt satıra geçmek için kaynak görünümünde &#8249;br /&#8250; tagını ekleyiniz.</span></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <textarea id="aciklamaTXT" placeholder="" class="ckeditor" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                                <asp:FileUpload ID="fluDosya" runat="server" Width="100%" CssClass="form-control-file" />
                            </td>
                            <td style="text-align:left;padding-left:5px; width:80px;">
                                <asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Yükle" OnClick="kaydetBTN_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right"><p>Önerilen (Genişlik: 250px, Yükseklik: 250px)</p></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
          		    <hr />
                      
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 desc">
						<div class="project-wrapper">
		                    <div class="project">
		                        <div class="photo-wrapper" style="background:none;">
                                    <asp:Button ID="silBTN" class="btn btn-danger" runat="server" Text="Seçimi Sil" OnClick="silBTN_Click" />
		                            <asp:Label ID="sorguSonucu" runat="server" ForeColor="#FFFFFF" Visible="False"
                                        Text="Hiçbir kayıt bulunamadı." CssClass="btn btn-danger resimBilgi"></asp:Label>
                    
                                    <asp:GridView ID="GridView_resimler" DataKeyNames="id" 
                                        AutoGenerateColumns="False" CellPadding="5" runat="server"  
                                        CssClass="tabloBaslik" onselectedindexchanged="GridView_resimler_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="25px">
                                            <ItemTemplate>
                                                 <asp:CheckBox ID="secim" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="30px">
                                            <ItemStyle Width="30px" CssClass="tabloTD"></ItemStyle>
                                            <HeaderStyle CssClass="tabloBasliklari" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Resim" DataField="img" ItemStyle-Width="170px" >
                                            <ItemStyle Width="170px" CssClass="tabloTD"></ItemStyle>
                                            <HeaderStyle CssClass="tabloBasliklari" />
                                        </asp:BoundField>
                                        <asp:ButtonField ButtonType="Button" CommandName="Select" ControlStyle-CssClass="gitBTN" ItemStyle-Width="30px" Text=" "/>
                                    </Columns>
                                    </asp:GridView>
                            </div>
                        </div>
                    </div>
					</div><!-- col-lg-4 -->
                      <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 desc">
						<div class="project-wrapper">
		                    <div class="project">
		                        <div class="photo-wrapper" style="background:none;">
                                    <div class="ResimKutusu">
                                        <asp:Image ID="ResimKutusu" runat="server" ImageUrl="../../img/slider/onizleme.jpg" CssClass="Resim" />
                                    </div>
		                        </div>
		                    </div>
		                </div>
					</div><!-- col-lg-4 -->
          	</div>
		 </section>
    </section>
</asp:Content>

