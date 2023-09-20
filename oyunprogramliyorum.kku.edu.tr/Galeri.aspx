<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Galeri.aspx.cs" Inherits="Galeri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--=========== BEGIN GALLERY SECTION ================-->
    <section id="gallery">
      <div class="container">
        <div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="gallery-area">
              <!-- Start Second Image Album  -->
              <div class="my-simple-gallery">
                <div class="section-heading">
                  <h2>FOTOĞRAF GALERİSİ</h2>
                  <div class="line"></div>
                </div>
                <div class="row">
                    <asp:Repeater ID="rptgaleri" runat="server">
                        <ItemTemplate>
                          <figure itemprop="associatedMedia" class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                            <a class="gallery-iteam" href="img/galeri/<%#Eval("img") %>" itemprop="contentUrl" data-size="1500x1024">
                              <img src="img/galeri/<%#Eval("img") %>" itemprop="thumbnail" alt="Image description" style="width:2000px;" />
                               <span class="image-effect"></span>
                            </a>                           
                          </figure>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
              </div>
              <!-- End Second Image Album  -->

              <!-- This Section only for Lightbox view -->
              <!-- Root element of PhotoSwipe. Must have class pswp. -->
              <div class="pswp" tabindex="-1" role="dialog" aria-hidden="true">

                <!-- Background of PhotoSwipe. 
                     It's a separate element, as animating opacity is faster than rgba(). -->
                <div class="pswp__bg"></div>

                <!-- Slides wrapper with overflow:hidden. -->
                <div class="pswp__scroll-wrap">

                  <!-- Container that holds slides. PhotoSwipe keeps only 3 slides in DOM to save memory. -->
                  <!-- don't modify these 3 pswp__item elements, data is added later on. -->
                  <div class="pswp__container">
                      <div class="pswp__item"></div>
                      <div class="pswp__item"></div>
                      <div class="pswp__item"></div>
                  </div>

                  <!-- Default (PhotoSwipeUI_Default) interface on top of sliding area. Can be changed. -->
                  <div class="pswp__ui pswp__ui--hidden">
                    <div class="pswp__top-bar">

                        <!--  Controls are self-explanatory. Order can be changed. -->

                        <div class="pswp__counter"></div>

                        <a class="pswp__button pswp__button--close" title="Close (Esc)"></a>

                        <a class="pswp__button pswp__button--fs" title="Toggle fullscreen"></a>

                        <a class="pswp__button pswp__button--zoom" title="Zoom in/out"></a>

                        <!-- Preloader demo http://codepen.io/dimsemenov/pen/yyBWoR -->
                        <!-- element will get class pswp__preloader--active when preloader is running -->
                        <div class="pswp__preloader">
                            <div class="pswp__preloader__icn">
                              <div class="pswp__preloader__cut">
                                <div class="pswp__preloader__donut"></div>
                              </div>
                            </div>
                        </div>
                    </div>

                    <div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">
                        <div class="pswp__share-tooltip"></div> 
                    </div>

                    <a class="pswp__button pswp__button--arrow--left" title="Previous (arrow left)">
                    </a>

                    <a class="pswp__button pswp__button--arrow--right" title="Next (arrow right)">
                    </a>

                    <div class="pswp__caption">
                        <div class="pswp__caption__center"></div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!--=========== END GALLERY SECTION ================-->
</asp:Content>

