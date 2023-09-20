<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Proje.aspx.cs" Inherits="ProjeGoruntule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--Vertical Tab-->
	<div class="categories-section main-grid-border">
		<div class="container">
			<h2 class="head">
                <asp:Label ID="baslikTXT" runat="server" Text="Label"></asp:Label></h2>
			<div class="category-list">
				<div id="parentVerticalTab">
					<ul class="resp-tabs-list hor_1">
						<li>Proje Hakkında</li>
						<li>Proje Ekibi</li>
						<li>Yayınlar</li>
						<li>Duyurular</li>
					</ul>
					<div class="resp-tabs-container hor_1">
					  <span style="display:block;visibility:hidden;" data-toggle="modal" data-target="#myModal"></span>
						<div class="tab">
                        	<span class="active total" style="display:block;">
                        	  <strong>Proje Hakkında</strong>
                      	  	</span>
                            <asp:Label ID="projeHakkindaTXT" runat="server" Text="Label"></asp:Label>
						</div>
						<div class="tab">
							<span class="active total" style="display:block;">
                            	<strong>Proje Ekibi</strong>
                            </span>
                            <asp:Label ID="projeEkibiTXT" runat="server" Text="Label"></asp:Label>
						</div>
						<div class="tab">
							<span class="active total" style="display:block;">
                            	<strong>Yayınlar</strong>
                            </span>
                            <asp:Label ID="yayinlarTXT" runat="server" Text="Label"></asp:Label>
						</div>
						<div class="tab">
							<span class="active total" style="display:block;">
                            	<strong>Duyurular</strong>
                            </span>
                            <asp:Label ID="duyurularTXT" runat="server" Text="Label"></asp:Label>
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
			</div>
		</div>
	</div>
	<!--Plug-in Initialisation-->
	<script type="text/javascript">
	    $(document).ready(function () {

	        //Vertical Tab
	        $('#parentVerticalTab').easyResponsiveTabs({
	            type: 'vertical', //Types: default, vertical, accordion
	            width: 'auto', //auto or any width like 600px
	            fit: true, // 100% fit in a container
	            closed: 'accordion', // Start closed if in accordion view
	            tabidentify: 'hor_1', // The tab groups identifier
	            activate: function (event) { // Callback function if tab is switched
	                var $tab = $(this);
	                var $info = $('#nested-tabInfo2');
	                var $name = $('span', $info);
	                $name.text($tab.text());
	                $info.show();
	            }
	        });
	    });
</script>
	<!-- //Categories -->
</asp:Content>

