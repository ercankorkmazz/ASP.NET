<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="sliderArea">
          <div id="da-slider" class="da-slider">
              <asp:Repeater ID="rptslider" runat="server">
                <ItemTemplate>
				    <div class="da-slide">
					    <h2 style="font-family:'Comic Sans MS', cursive;font-size:50px; margin-top:30px;"><%#Eval("baslik") %></h2>
                        <p style="font-family:'Comic Sans MS', cursive;font-size:24px; color:#FFF; width:500px; height:auto;"><%#Eval("aciklama") %></p>
					    <div class="da-img"><img src='img/slider/<%#Eval("img") %>' alt="image01" style="width:370px; height:370px; margin-top:-30px; margin-left:-100px;" /></div>
				    </div>       
                </ItemTemplate>
              </asp:Repeater>
              <nav class="da-arrows">
		        <span class="da-arrows-prev"></span>
				<span class="da-arrows-next"></span>
			  </nav> 
            </div> 
    </section>
    
    <!--===== Hakkında Bölümü Başı =====-->
    
    <section id="testimonial" style="">
      <div class="container">
        <div class="row">
          <div class="col-lg-12 col-md-12">
            <div class="testimonial-area">
             <!-- Start Service Title -->
              <div class="testimonial-area">
                <ul class="testimonial-nav">
                  <li>
                    <div class="single-testimonial">
                      <div class="section-heading">
                        <h2>PROJE HAKKINDA</h2>
                        <div class="line"></div>
                      </div>
                      <div class="testimonial-cotent" style="margin-top:0;">
                          <asp:Repeater ID="rptsayfa" runat="server">
                            <ItemTemplate>
                                <%#Eval("hakkinda") %>
                            </ItemTemplate>
                          </asp:Repeater>
                          <div style="padding:10px; border:1px dotted #000; margin-top:20px;">
                            <h5 style="text-align:center; font-weight:bold;">Katılımcı listesini indirmek için <a href="dosya/KatilimciListesi.docx" style="color:#550;">tıklayınmız.</a></h5>
                          </div>
                      </div>
                    </div>
                  </li>            
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    
    <!--===== Hakkında Bölümü Sonu =====-->
</asp:Content>

