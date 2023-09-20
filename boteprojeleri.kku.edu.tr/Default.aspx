<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- content-starts-here -->
		<div class="content">
		  <div class="trending-ads">
			  <div class="container">
				<!-- slider -->
				<div class="trend-ads">
                <asp:Repeater ID="rptKategoriler" runat="server" OnItemCommand="rptKategoriler_ItemCommand" onitemdatabound="rptKategoriler_ItemDataBound">
                    <ItemTemplate>
                        <div id="w">
					        <h2 class="Baslik"><%#Eval("baslik") %></h2>
                            <nav class="slidernav" style="float:right;">
                              <div id='<%#Eval("id","navbtns{0}") %>'>
                                <a href="#" class="previous" id="prevBTN">&nbsp;</a>
                                <a href="#" class="next" id="nextBTN">&nbsp;</a>
                              </div>
                            </nav>
                            <hr />
                            <div class="<%#Eval("id","crsl-items{0}") %>" data-navigation='<%#Eval("id","navbtns{0}") %>'>
                              <div class="crsl-wrap">
                                
                                <asp:Repeater ID="RepeaterProjeler" runat="server">
                                    <ItemTemplate>  
                                        <div class="crsl-item">
                                          <div class="thumbnail">
                                            <img style="background:#eee;" src='<%#Eval("img")==string.Empty?"img/projeler/resimyok.jpg":Eval("img","img/projeler/{0}") %>' alt="Yükleniyor...">
                                          </div>
                          
                                          <h3><a href='<%# Convert.ToInt32(Eval("kontrol"))==0?Eval("id","Proje.aspx?id={0}"):Eval("url") %>'><%#Eval("projeBasligi") %></a></h3>
                          
                                          <p><%#Eval("kisaAciklama") %></p>
                          
                                          <p class="readmore"><a href='<%# Convert.ToInt32(Eval("kontrol"))==0?Eval("id","Proje.aspx?id={0}"):Eval("url") %>'>Daha fazla bilgi al &raquo;</a></p>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                        
                              </div><!-- @end .crsl-wrap -->
                            </div><!-- @end .crsl-items -->
                          </div><!-- @end #w -->
                           <div class="clearfix" style="padding:10px;">&nbsp;</div>
                          <script type="text/javascript">
                              $(function () {
                                  $('.<%#Eval("id","crsl-items{0}") %>').carousel({
                                      visible: 4,
                                      itemMinWidth: 180,
                                      itemEqualHeight: 370,
                                      itemMargin: 9,
                                  });

                                  $("a[href=#]").on('click', function (e) {
                                      e.preventDefault();
                                  });
                              });
				        </script>
                    </ItemTemplate>
                </asp:Repeater> 
			</div>
			<!-- //slider -->				
			</div>
		</div>
    </div>
<!-- content-end-here -->
</asp:Content>

